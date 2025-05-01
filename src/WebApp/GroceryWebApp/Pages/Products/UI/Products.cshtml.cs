using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryWebApp.Pages.Products.Services;
using GroceryWebApp.Pages.Products.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;

namespace GroceryWebApp.Pages.Products.UI
{
    public class ProductsModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductsModel(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [BindProperty(SupportsGet = true)]
        public int Cursor { get; set; } = 1;

        public IEnumerable<ProductDetail> Products { get; set; } = new List<ProductDetail>();

        public async Task<IActionResult> OnGetAsync()
        {
            
            if(!HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                CookieOptions option = new CookieOptions();
                //option.Expires = DateTime.Now.AddMinutes(100);
                option.HttpOnly = true;
                option.SameSite = SameSiteMode.Strict;
                option.Domain = "localhost";
                HttpContext.Response.Cookies.Append("UserId", Guid.NewGuid().ToString(), option);
            }

            Products = await _productService.GetProductDetails();

            return Page();
        }

        //public IEnumerable<ProductResponseModel> PartialProducts { get; set; } = new List<ProductResponseModel>();
        //public async Task<IActionResult> OnGetScrollGetContent()
        //{
       
        //    PartialProducts =  await _productService.GetProducts();

        //    //return Partial("_ScrollForMorePartial");

        //    return new PartialViewResult()
        //    {
        //        ViewName = "~/Pages/Products/UI/Partial/_ScrollForMorePartial.cshtml",
        //        ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
        //        {
        //            Model = PartialProducts,
        //        }
        //    };

        //}

        //public  Task<IActionResult> OnPostAddToCartAsync(string productId)
        //{
        //    //var product = await _catalogService.GetCatalog(productId);

        //    //var userName = "swn";
        //    //var basket = await _basketService.GetBasket(userName);

        //    //basket.Items.Add(new BasketItemModel
        //    //{
        //    //    ProductId = productId,
        //    //    ProductName = product.Name,
        //    //    Price = product.Price,
        //    //    Quantity = 1,
        //    //    Color = "Black"
        //    //});

        //    //var basketUpdated = await _basketService.UpdateBasket(basket);

        //    return null;
        //}
    }
}
