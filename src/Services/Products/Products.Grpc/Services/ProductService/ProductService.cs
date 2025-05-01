using Newtonsoft.Json;
using Products.Grpc.Entities;
using Products.Grpc.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Products.Grpc.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Product> GetProduct(int productid)
        {
            var response = await _client.GetAsync($"/Api/Products/GetProducts/{productid}");
            var res = await response.ReadContentAs<Product>();
            return res;
        }
        public async Task<ProductsCategory> GetProductsByCategory(int categoryId)
        {
            var response = await _client.GetAsync($"/Api/Products/GetProductsByCategory/{categoryId}");
            var res = await response.ReadContentAs<IEnumerable<Product>>();
            return new ProductsCategory() { ProductsModel = res };
        }

        public async Task<ProductDetail> GetProductDetail(int productdetailid)
        {
            var response = await _client.GetAsync($"/Api/Products/GetProductDetailsById/{productdetailid}");
            var res = await response.ReadContentAs<ProductDetail>();
            return res;
        }

        public async Task<int> UpdateProductQuantityForChecout(int productDetailId, int quantity, bool isCheckout)
        {
            var prodUpdQtyCmd = new ProdUpdQtyCommand(productDetailId, quantity, isCheckout);
            var response = await _client.PostAsJson($"/Api/Products/UpdateProductQuantityForChecout", prodUpdQtyCmd);
            var res = await response.ReadContentAs<int>();
            return res;
        }
    }
}
