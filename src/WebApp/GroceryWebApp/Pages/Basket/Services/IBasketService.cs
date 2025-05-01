using GroceryWebApp.Pages.Basket.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Basket.Services
{
    public interface IBasketService
    {
        Task<int> CreateBasket(BasketModel model);
        Task<BasketShoppingModel> GetBasket(string basketid);
        Task<string> DeleteBasket(string basketId, string basketItem = "");
        Task<string> CreateOrUpdateBasket([FromBody] BasketModel basket);

        Task<string> CheckoutBasket(BasketCheckout basket);
        Task<string> BookItemsForCheckout(BookItemsForCheckOut basket);
        Task<IEnumerable<BookItemsForCheckOut>> GetBookedChkItems(string userid);
        Task<IEnumerable<BookingIdList>> GetUserOrders(string userid);
        Task<IEnumerable<BookingHistoryList>> GetBookingHistory(string orderid);
        Task<int> UpdateBasketUserId([FromBody] BasketUserIdUpdate basketuseridupdate);
    }

}
