using Basket.Application.Features.Commands.Create;
using Basket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Persistance
{
    public interface IBasketRepository : IAsyncRepository<BasketEnt>
    {
        Task<List<BasketEnt>> GetBasket(string UserId);
        Task<int> CreateOrUpdateBasket(BasketEnt basket);
        Task DeleteBasket(string UserId, string productDetailId);
        Task CheckoutBasket(BasketCheckout basket);
        Task BookItemsForCheckount(BookItemsForCheckOut basket);
        Task RollBackItemsForCheckount(BookItemsForCheckOut basket);
        Task<IEnumerable<BookItemsForCheckOut>> GetItemsForCheckount(string userid);
        Task SaveBookingHistory(BookingHistory hostory);
        Task DeleteBookItemsForCheckount(string userid);
        Task<List<BookingHistory>> GetOrderHistory(string orderid);
        Task<List<BasketCheckout>> GetUserOrders(string userId);
        Task UpdateBasketUserId(string userguid, string userid);
    }
}
