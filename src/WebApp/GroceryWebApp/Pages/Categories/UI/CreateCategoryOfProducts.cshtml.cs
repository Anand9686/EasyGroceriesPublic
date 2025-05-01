using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryWebApp.Pages.Categories.Services;
using GroceryWebApp.Pages.Products.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryWebApp.Pages.Categories.UI
{
    public class CreateCategoryOfProductsModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public CreateCategoryOfProductsModel(ICategoryService categoryService, IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Products { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync()
        {
            var CategoriesList = await _categoryService.GetCategories();
            Categories = CategoriesList.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CategoryName }).ToList();

            var ProductsList = await _productService.GetProducts();
            Products = ProductsList.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name + " - " + c.Units }).ToList();


            return Page();
        }
    }
}
