using Products.Domain;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Persistance
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProducts(int productid);
        Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<ProductDetail>> GetScrollContent(int page, int size);

        Task<int> CreateProductDetails(ProductDetails productDetails);

        Task<IEnumerable<ProductDetail>> GetProductDetails(int productId, int categoryId, int vendorId);

        Task<ProductDetail> GetProductDetailById(int productDetailId);
        Task<IEnumerable<ProductDetail>> GetProductDetails();

        Task<int> UpdateProductQuantityForChecout(int productDetailId, int quantity, bool isCheckout);
    }
}
