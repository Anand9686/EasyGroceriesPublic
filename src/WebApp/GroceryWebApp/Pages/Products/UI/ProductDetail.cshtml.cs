using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryWebApp.Pages.Categories.Services;
using GroceryWebApp.Pages.Products.Services;
using GroceryWebApp.Pages.Vendor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryWebApp.Pages.Products.UI
{
    public class ProductDetailModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IVendorService _vendorService;
        public ProductDetailModel(ICategoryService categoryService, IProductService productService, IVendorService vendorService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _vendorService = vendorService ?? throw new ArgumentNullException(nameof(vendorService));
        }

        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Products { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Vendors { get; set; } = new List<SelectListItem>();
        public async Task<IActionResult> OnGetAsync()
        {
            var CategoriesList = await _categoryService.GetCategories();
            Categories = CategoriesList.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CategoryName }).ToList();

            var ProductsList = await _productService.GetProducts();
            Products = ProductsList.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            var VendorsList = await _vendorService.GetVendors();
            Vendors = VendorsList.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();


            return Page();
        }
    }
}
