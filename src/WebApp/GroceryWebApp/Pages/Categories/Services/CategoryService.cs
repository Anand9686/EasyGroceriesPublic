using GroceryWebApp.Pages.Categories.Model;
using GroceryWebApp.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetCategories()
        {
            var response = await _client.GetAsync($"/Api/Categories");
            return await response.ReadContentAs<List<CategoryResponseModel>>();
        }

        public async Task<int> CreateCategories(CategoryResponseModel catmodel)
        {
            var response = await _client.PostAsJson($"/Api/Categories", catmodel);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<int> CreateCategoryProducts(CategoryProductsModel model)
        {
            var response = await _client.PostAsJson($"/Api/Categories/CreateCategoryProducts", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        //public async Task<int> CreateUpdateCategories(CategoryProducts catmodel)
        //{
        //    var response = await _client.PostAsJson($"/Api/Categories", catmodel);
        //    if (response.IsSuccessStatusCode)
        //        return await response.ReadContentAs<int>();
        //    else
        //    {
        //        throw new Exception("Something went wrong when calling api.");
        //    }
        //}
    }
}
