using GroceryWebApp.Pages.Categories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Categories.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseModel>> GetCategories();
        Task<int> CreateCategories(CategoryResponseModel model);
        //Task<int> CreateUpdateCategories(CategoryProducts model);

        Task<int> CreateCategoryProducts(CategoryProductsModel model);

    }
}
