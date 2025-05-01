using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryWebApp.Pages.Vendor.Services;
using GroceryWebApp.Pages.Products.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using GroceryWebApp.Pages.Vendor.Model;
using GroceryWebApp.Pages.Categories.Model;
using GroceryWebApp.Pages.Categories.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryWebApp.Pages.Vendor.UI
{
    public class VendorProductsModel : PageModel
    {
        private readonly IVendorService _vendorService;
        private readonly ICategoryService _categoryService;

        public VendorProductsModel(IVendorService productService, ICategoryService categoryService)
        {
            _vendorService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [BindProperty(SupportsGet = true)]
        public int Cursor { get; set; } = 1;

        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Vendors { get; set; } = new List<SelectListItem>();
        //public IEnumerable<VendorResponseModel> Products { get; set; } = new List<VendorResponseModel>();


        public async Task<IActionResult> OnGetAsync()
        {
            
            if(!HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(100);
                HttpContext.Response.Cookies.Append("UserId", Guid.NewGuid().ToString(), option);
            }

            var CategoriesList = await _categoryService.GetCategories();
            Categories = CategoriesList.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CategoryName }).ToList();

            var VednorsList = await _vendorService.GetVendors();
            Vendors = VednorsList.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

           // Products = await _vendorService.GetVendors();

            return Page();
        }

    }
}
