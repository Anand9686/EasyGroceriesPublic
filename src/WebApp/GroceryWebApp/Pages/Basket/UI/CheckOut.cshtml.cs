using System;
using System.Threading.Tasks;
using GroceryWebApp.Pages.Basket.Model;
using GroceryWebApp.Pages.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryWebApp.Pages.Basket.UI
{
    [Authorize]
    public class CheckOutModel : PageModel
    {
        private readonly IBasketService _basketService;
       // private readonly IOrderService _orderService;

        public CheckOutModel(IBasketService basketService)//, IOrderService orderService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
          //  _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [BindProperty]
        public BasketCheckout Order { get; set; }

        public BasketShoppingModel Cart { get; set; } = new BasketShoppingModel();

        public async Task<IActionResult> OnGetAsync(string userid)
        {
            //var userid = "";
            //if (HttpContext.Request.Cookies.ContainsKey("UserId"))
            //{
            //    userid = HttpContext.Request.Cookies["UserId"];
            //}
            Cart = await _basketService.GetBasket(userid);

            var bookedChekItems = await _basketService.GetBookedChkItems(userid);
            if (((System.Collections.Generic.List<GroceryWebApp.Pages.Basket.Model.BookItemsForCheckOut>)bookedChekItems).Count==0)
            {
                // bookedChekItems
                foreach (var item in Cart.Items)
                {

                    var basketitems = new BookItemsForCheckOut();
                    basketitems.ProductDetailId = item.ProductDetailId;
                    basketitems.UserId = item.UserID;
                    basketitems.CartCost = item.CartCost;
                    basketitems.CostToCompany = item.CostToCompany;
                    basketitems.Discount = item.Discount;
                    basketitems.DiscountEffectiveEndDate = item.DiscountEffectiveEndDate;
                    basketitems.DiscountEffectiveStartDate = item.DiscountEffectiveStartDate;
                    basketitems.Quantity = item.Quantity;
                    basketitems.ProductSubDescription = item.ProductSubDescription;
                    basketitems.UnitDetailDesc = item.UnitDetailDesc;
                    basketitems.productdetailedInfo = item.productdetailedInfo;

                    await _basketService.BookItemsForCheckout(basketitems);
               }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var userid = "";
            if (HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                userid = HttpContext.Request.Cookies["UserId"];
            }
            Cart = await _basketService.GetBasket(userid);
            var bookedChekItems = await _basketService.GetBookedChkItems(userid);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserId = Cart.BasketId;
            Order.TotalPrice = Convert.ToDecimal(Cart.TotalPrice);
            Order.BasketItems = bookedChekItems;
            await _basketService.CheckoutBasket(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}