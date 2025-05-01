using Products.Grpc.Entities;
using Products.Grpc.Protos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Grpc.Services.ProductServices
{
    public interface IProductService
    {
        Task<Product> GetProduct(int productid);
        Task<ProductsCategory> GetProductsByCategory(int categoryId);
        Task<ProductDetail> GetProductDetail(int productdetailid);
        Task<int> UpdateProductQuantityForChecout(int productDetailId, int quantity, bool isCheckout);
    }
}
