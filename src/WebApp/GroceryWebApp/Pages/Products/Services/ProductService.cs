using GroceryWebApp.Extensions;
using GroceryWebApp.Pages.Products.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProducts()
        {
            var response = await _client.GetAsync($"/Api/Products");
            return await response.ReadContentAs<List<ProductResponseModel>>();
        }
        public async Task<IEnumerable<ProductResponseModel>> GetProductsByCategory(int categoryId)
        {
            var response = await _client.GetAsync($"/Api/Products/GetProductsByCategory/{categoryId}");
            return await response.ReadContentAs<List<ProductResponseModel>>();
        }
        public async Task<int> CreateProduct(ProductResponseModel prodmodel)
        {
            var response = await _client.PostAsJson($"/Api/Products", prodmodel);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<IEnumerable<ProductDetail>> GetScrollContent(int page, int size)
        {
            var response = await _client.GetAsync($"/Api/Products/GetScrollContent/{page}/{size}");
            
            return await response.ReadContentAs<IEnumerable<ProductDetail>>();
        }

        public async Task<int> CreateProductDetails(ProductDetails productDetails)
        {
            var response = await _client.PostAsJson($"/Api/Products/CreateProductDetails", productDetails);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<IEnumerable<ProductDetail>> GetProductsDetail(int productId, int categoryId, int vendorId)
        {
            var response = await _client.GetAsync($"/Api/Products/GetProductDetail/{productId}/{categoryId}/{vendorId}");

            return await response.ReadContentAs<IEnumerable<ProductDetail>>();
        }

        public async Task<IEnumerable<ProductDetail>> GetProductDetails()
        {
            var response = await _client.GetAsync($"/Api/Products/GetProductDetails");

            return await response.ReadContentAs<IEnumerable<ProductDetail>>();
        }

        public async Task<ProductDetail> GetProductDetailsById(int productDetailId)
        {
            var response = await _client.GetAsync($"/Api/Products/GetProductDetailsById/{productDetailId}");

            return await response.ReadContentAs<ProductDetail>();
        }
    }
}
