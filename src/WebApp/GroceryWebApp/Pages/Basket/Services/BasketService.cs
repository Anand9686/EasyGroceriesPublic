using GroceryWebApp.Extensions;
using GroceryWebApp.Pages.Basket.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<int> CreateBasket(BasketModel prodmodel)
        {
            var response = await _client.PostAsJson($"/Api/Basket", prodmodel);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<BasketShoppingModel> GetBasket(string basketid)
        {
            var response = await _client.GetAsync($"/Api/Basket/{basketid}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<BasketShoppingModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<string> CreateOrUpdateBasket(BasketModel basket)
        {
            var response = await _client.PostAsJson($"/Api/Basket/", basket);
            return await response.ReadContentAs<string>();
        }

        public async Task<string> DeleteBasket(string userid, string productdetailid)
        {
            var response = await _client.DeleteAsync($"/Api/Basket/{userid}/{productdetailid}");
            return string.Empty;
        }

        public async Task<string> CheckoutBasket(BasketCheckout basket)
        {
            var response = await _client.PostAsJson($"/api/Basket/Checkout", basket);
            return string.Empty;
        }

        public async Task<string> BookItemsForCheckout(BookItemsForCheckOut basket)
        {
            var response = await _client.PostAsJson($"/api/Basket/BookItemsForCheckOut", basket);
            return response.ToString();
        }

        public async Task<IEnumerable<BookItemsForCheckOut>> GetBookedChkItems(string userid)
        {
            var response = await _client.GetAsync($"/api/Basket/GetBookedChkItems/{userid}");
            return await response.ReadContentAs<IEnumerable<BookItemsForCheckOut>>();
            //return response;
        }

        public async Task<IEnumerable<BookingIdList>> GetUserOrders(string userid)
        {
            var response = await _client.GetAsync($"/api/Basket/GetUserOrders/{userid}");
            return await response.ReadContentAs<IEnumerable<BookingIdList>>();

        }

        public async Task<IEnumerable<BookingHistoryList>> GetBookingHistory(string orderid)
        {
            var response = await _client.GetAsync($"/api/Basket/GetBookingHistory/{orderid}");
            return await response.ReadContentAs<IEnumerable<BookingHistoryList>>();
        }
        public async Task<int> UpdateBasketUserId([FromBody] BasketUserIdUpdate basketuseridupdate)
        {
            var response = await _client.PostAsJson($"/api/Basket/UpdateBasketUserId", basketuseridupdate);
            return await response.ReadContentAs<int>();
        }
    }
}
