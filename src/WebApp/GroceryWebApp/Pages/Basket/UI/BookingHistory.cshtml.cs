using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryWebApp.Pages.Basket.Model;
using GroceryWebApp.Pages.Basket.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryWebApp.Pages.Basket.UI
{
    public class BookingHistoryModel : PageModel
    {
        private readonly IBasketService _basketService;

        public BookingHistoryModel(IBasketService basketService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IEnumerable<SelectListItem> OrderIds { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync()
        {
            var userid = "";
            if (HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                userid = HttpContext.Request.Cookies["UserId"];
            }
            var OrderHistory = await _basketService.GetUserOrders(userid);

            OrderIds = OrderHistory.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() + " - " + c.CreatedDate.ToString("dd-MM-yyyy") }).ToList();

            return Page();
        }
    }
}
