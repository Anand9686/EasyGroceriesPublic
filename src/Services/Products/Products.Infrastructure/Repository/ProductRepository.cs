using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Products.Application.Persistance;
using Products.Domain.Entites;
using Products.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var productList = await _dbContext.Product
                    .Where(q => q.Flag == true)
                    .ToListAsync();
            //var productList = await(from p in _dbContext.Product
            //       join pd in _dbContext.ProductDetail
            //        on p.Id equals pd.ProductId
            //       where p.Flag == true
            //       select new Product() { Id=p.Id,Name=p.Name,Description=p.Description, Price=pd.CartCost,Discount=pd.Discount,DiscountValidDate=pd.DiscountEffectiveEndDate,ImageName=pd.ImageName,Unit=pd.UnitId.ToString(), Units = pd.UnitId.ToString() })
            //                             .ToListAsync();
            return productList;
        }

        public async Task<IEnumerable<Product>> GetProducts(int productid)
        {
            //var productItems = await _dbContext.Product
            //        .Where(q => q.Flag == true && q.Id == productid).ToListAsync();
            var productItems = await(from p in _dbContext.Product
                   join pd in _dbContext.ProductDetail
                    on p.Id equals pd.ProductId
                   where p.Flag == true && p.Id == productid
                   select new Product() { Id = p.Id, Name = p.Name, Description = p.Description, Price = pd.CartCost, Discount = pd.Discount, DiscountValidDate = pd.DiscountEffectiveEndDate, ImageName = pd.ImageName, Unit = pd.UnitId.ToString(), Units = pd.UnitId.ToString() })
                                         .ToListAsync();
            return productItems;
        }

        public async Task<IEnumerable<ProductDetail>> GetProductDetails()
        {
            //var productList = await _dbContext.Product
            //        .Where(q => q.Flag == true)
            //        .ToListAsync();
            var productList = await (from p in _dbContext.Product
                                     join pd in _dbContext.ProductDetail
                                      on p.Id equals pd.ProductId
                                     where p.Flag == true
                                     select pd)
                                         .ToListAsync();
            return productList;
        }

        public async Task<ProductDetail> GetProductDetailById(int productDetailId)
        {
            //var productItems = await _dbContext.Product
            //        .Where(q => q.Flag == true && q.Id == productid).ToListAsync();
            var productItems = await (from p in _dbContext.Product
                                      join pd in _dbContext.ProductDetail
                                       on p.Id equals pd.ProductId
                                      where p.Flag == true && pd.Id == productDetailId
                                      select pd).FirstOrDefaultAsync<ProductDetail>();
                                      
            return productItems;
        }


        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            var productItems = await(from p in _dbContext.Product join pc in _dbContext.ProductsCategory
                                       on p.Id equals pc.ProductId
                                        where p.Flag == true && pc.CategoryId == categoryId
                                         select p)
                                         .ToListAsync();// && q.Category == categoryId
            return productItems;
        }
        public async Task<IEnumerable<ProductDetail>> GetScrollContent(int page, int size)
        {
            var sqlQ = $"Select derived.* from (SELECT row_number() over(order by id) RowNum, products.productdetail.* FROM products.productdetail) as derived where derived.RowNum between @start and @end";
            var productItems = await _dbContext.ProductDetail.FromSqlRaw<ProductDetail>(sqlQ, new MySqlParameter("@start", ((page - 1) * size) + 1),
                new MySqlParameter("@end", (page * size)))
                    .Where(q => q.Flag == true).ToListAsync();
            return productItems;
        }

        public async Task<int> CreateProductDetails(ProductDetails productDetails)
        {
            var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                var prodDetails = productDetails.ProductDetail.FirstOrDefault<ProductDetail>();
                prodDetails.CreatedBy = "self";

                prodDetails.CreatedBy = "self";
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ProductDetail, ProductDetailHistory>().ReverseMap();
                    cfg.CreateMap<ProductDetail, ProductStockDetail>().ReverseMap();
                });
                var mapper = new Mapper(config);
               

                if (prodDetails.Id == 0)
                {
                    await _dbContext.ProductDetail.AddAsync(prodDetails);
                    await _dbContext.SaveChangesAsync();

                    var prodDetailHistory = mapper.Map<ProductDetailHistory>(prodDetails);
                    prodDetailHistory.Id = 0;
                    prodDetailHistory.ProdDetailId = prodDetails.Id;
                    await _dbContext.AddAsync(prodDetailHistory);
                    await _dbContext.SaveChangesAsync();

                    var prodStockDetails = mapper.Map<ProductStockDetail>(prodDetails);
                    prodStockDetails.Id = 0;
                    prodStockDetails.ProdDetailHistoryId = prodDetailHistory.Id;
                    await _dbContext.AddAsync(prodStockDetails);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    var getProdDetails = GetProductDetailsById(prodDetails.Id);
                    var prodDetailHistory = mapper.Map<ProductDetailHistory>(getProdDetails);
                    prodDetailHistory.Id = 0;
                    prodDetailHistory.ProdDetailId = getProdDetails.Id;
                    prodDetailHistory.LastModifiedBy = "Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update";
                    prodDetailHistory.LastModifiedDate = DateTime.UtcNow;
                    await _dbContext.AddAsync(prodDetailHistory);
                    await _dbContext.SaveChangesAsync();

                    prodDetails.LastModifiedBy = "Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update";
                    prodDetails.LastModifiedDate = DateTime.UtcNow;
                    var prodStockDetails = mapper.Map<ProductStockDetail>(prodDetails);
                    prodStockDetails.Id = 0;
                    prodStockDetails.ProdDetailHistoryId = prodDetailHistory.Id;
                    prodStockDetails.LastModifiedBy = "Snapshot before update. Product Stcok detail will have new  addition info";
                    prodStockDetails.LastModifiedDate= DateTime.UtcNow;
                    await _dbContext.AddAsync(prodStockDetails);
                    await _dbContext.SaveChangesAsync();
                   
                    _dbContext.UpdateRange(prodDetails);
                    await _dbContext.SaveChangesAsync();
                }
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }


            return 1;
        }

        private  ProductDetail GetProductDetailsById(int prodDetailsID)
        {
            var productDetails =  _dbContext.ProductDetail.AsNoTracking()
                    .Where(q => q.Flag == true && q.Id== prodDetailsID).FirstOrDefault<ProductDetail>();
            return productDetails;
        }
        public async Task<IEnumerable<ProductDetail>> GetProductDetails(int productId, int categoryId, int vendorId)
        {
            var productDetails =  await _dbContext.ProductDetail
                    .Where(q => q.Flag == true && q.ProductId == productId && q.CategoryId==categoryId && q.VendorId==vendorId).ToListAsync();
            return productDetails;
        }

        public async Task<int> UpdateProductQuantityForChecout(int productDetailId, int quantity,bool isCheckout)
        {
            var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            var item = await _dbContext.ProductDetail
                    .Where(q => q.Flag == true && q.Id == productDetailId).FirstOrDefaultAsync();
            if(isCheckout)
            {
                //Reduce quantity for basket checkout
                if (item.AvailableQuantity - quantity <= 0)
                {
                    transaction.Rollback();
                    return 0;
                }

                item.AvailableQuantity = item.AvailableQuantity - quantity;
            }
            else
            {
                //Update available quanitity for baske roll back during checkout
                item.AvailableQuantity = item.AvailableQuantity + quantity;
            }

             _dbContext.ProductDetail.Update(item);
            await _dbContext.SaveChangesAsync();
            transaction.Commit();

            return 1;
        }

    }
}
