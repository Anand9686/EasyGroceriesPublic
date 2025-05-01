using System;
using System.Linq;
using System.Threading.Tasks;
using GroceryWebApp.Pages.Basket.Model;
using GroceryWebApp.Pages.Basket.Services;
using GroceryWebApp.Pages.Utils.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryWebApp.Pages.Basket.UI
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;
        private readonly IUtilsService _utilService;
        public CartModel(IBasketService basketService, IUtilsService utilService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _utilService = utilService ?? throw new ArgumentNullException(nameof(utilService));

        }

        public BasketShoppingModel Cart { get; set; } = new BasketShoppingModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var userid = "";
            if (HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                userid = HttpContext.Request.Cookies["UserId"];
            }
            Cart = await _basketService.GetBasket(userid);

            foreach(var item in Cart.Items)
            {
                var unitList = await _utilService.GetUnitDetail(item.UnitId.ToString());
                item.Units = unitList.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.UnitDescription, Selected=(c.Id == Convert.ToInt32(item.UnitDetailId)) }).ToList();
            }

           
            // _utilService
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string userid, string productdetailId)
        {
            //var userid = "";
            //if (HttpContext.Request.Cookies.ContainsKey("UserId"))
            //{
            //    userid = HttpContext.Request.Cookies["UserId"];
            //}
            
            var basketUpdated = await _basketService.DeleteBasket(userid, productdetailId);
            var Cart = await _basketService.GetBasket(userid);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUpdateToCheckoutAsync(CartModel model)
        {
            //var userid = "";
            //if (HttpContext.Request.Cookies.ContainsKey("UserId"))
            //{
            //    userid = HttpContext.Request.Cookies["UserId"];
            //}

            //var basketUpdated = await _basketService.DeleteBasket(userid, productId);
            //var Cart = await _basketService.GetBasket(userid);
            //return RedirectToPage();
            return null;
        }
    }
}