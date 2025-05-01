using GroceryWebApp.Pages.Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Products.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseModel>> GetProducts();
        Task<int> CreateProduct(ProductResponseModel model);
        Task<IEnumerable<ProductDetail>> GetScrollContent(int page, int size);
        Task<IEnumerable<ProductResponseModel>> GetProductsByCategory(int categoryId);
        Task<int> CreateProductDetails(ProductDetails productDetails);

        Task<IEnumerable<ProductDetail>> GetProductsDetail(int productId, int categoryId, int vendorId);

        Task<IEnumerable<ProductDetail>> GetProductDetails();
        Task<ProductDetail> GetProductDetailsById(int productDetailId);
        
    }
}
