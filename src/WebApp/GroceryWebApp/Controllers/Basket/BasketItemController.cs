using GroceryWebApp.Pages.Basket.Model;
using GroceryWebApp.Pages.Basket.Services;
using GroceryWebApp.Pages.Products.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Controllers.Basket
{
  
    public class BasketItemController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        public BasketItemController(IBasketService basketService, IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromForm]string ProductDetailId)
        {
            int res;
            BasketModel bskt = new BasketModel();
            bskt.ProductDetailId = (int.TryParse(ProductDetailId, out res)?res:0);
            bskt.Quantity = 0;
            if(HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                var userid = HttpContext.Request.Cookies["UserId"];
                bskt.UserID = userid;
            }
            
            var response = await _basketService.CreateBasket(bskt);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket([FromForm] int basketid, int quantity,int productdetailid)
        {
            BasketModel bskt = new BasketModel();
            bskt.Id = basketid;
            bskt.Quantity = quantity;
            bskt.ProductDetailId = productdetailid;
            if (HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                var userid = HttpContext.Request.Cookies["UserId"];
                bskt.UserID = userid;
            }

            var response = await _basketService.CreateBasket(bskt);

            return Ok(response);
        }
        [HttpPost(Name = "UpdateBasketForType")]
        public async Task<IActionResult> UpdateBasketForType([FromForm] int basketId, int productId,int categoryId,int vendorId,int unitType,int quantity)
        {
            var productdetailList = await _productService.GetProductsDetail(productId,categoryId, vendorId);
            var prodDetail = productdetailList.Where(q => q.UnitDetailId == unitType.ToString()).FirstOrDefault();
            BasketModel bskt = new BasketModel();
            if (prodDetail != null && prodDetail.UnitDetailId == unitType.ToString() &&
                prodDetail.AvailableQuantity>0)
            {
                bskt.Id = basketId;
                bskt.ProductDetailId = prodDetail.Id;
                bskt.Quantity = quantity;
                if (HttpContext.Request.Cookies.ContainsKey("UserId"))
                {
                    var userid = HttpContext.Request.Cookies["UserId"];
                    bskt.UserID = userid;
                }
            }
            else
            {
                return Ok(0);
            }
            var response = await _basketService.CreateBasket(bskt);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<string> DeleteBasket(string userid, string productdetailid)
        {
           var response =  await _basketService.DeleteBasket(userid, productdetailid);
            return response;
        }
        [HttpPost(Name = "BookItemsForCheckount")]
        public async Task<string> BookItemsForCheckount(BookItemsForCheckOut basket)
        {
            var response = await _basketService.BookItemsForCheckout(basket);
            return response;
        }
        [Authorize]
        [HttpGet(Name = "GetUserOrders")]
        public async Task<IEnumerable<BookingIdList>> GetUserOrders(string userid)
        {
            var response = await _basketService.GetUserOrders(userid);
            return response;

        }

        [Authorize]
        [HttpGet(Name = "GetBookingHistory")]
        public async Task<IActionResult> GetBookingHistory(string orderid)
        {
            var response = await _basketService.GetBookingHistory(orderid);

            return PartialView("~/Pages/Basket/UI/Partial/_OrderHistory.cshtml", response); ;
        }

    }
}
