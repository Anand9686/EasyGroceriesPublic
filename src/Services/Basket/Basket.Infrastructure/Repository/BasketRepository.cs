using Microsoft.EntityFrameworkCore;
using Basket.Application.Persistance;
using Basket.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Domain.Entities;
using Basket.Application.Features.Commands.Create;

namespace Basket.Infrastructure.Repository
{
    public class BasketRepository: RepositoryBase<BasketEnt>, IBasketRepository
    {
        public BasketRepository(BasketContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> CreateOrUpdateBasket(BasketEnt basket)
        {
            if (string.IsNullOrEmpty(basket.UserId))
            {
                //Create new basket entry
                basket.UserId =  Guid.NewGuid().ToString();
                basket.Quantity = 1;
                await AddAsync(basket);
            }
            else if (!string.IsNullOrEmpty(basket.UserId))
            {
                var basketList = await GetBasketItems(basket.UserId, "");
                if(basketList.Count>0)
                {
                    var basketEnt = basketList.Where(q => q.Id == basket.Id && q.UserId == basket.UserId).FirstOrDefault<BasketEnt>();
                    if (basketEnt!=null)
                    {
                        //increment the product qunatity
                        if (basket.Quantity == 0)
                        {
                            basketEnt.Quantity += 1;
                        }
                        else
                        {
                            basketEnt.Quantity = basket.Quantity;
                            basketEnt.ProductDetailId = basket.ProductDetailId;
                        }

                        await UpdateAsync(basketEnt);
                    }
                    else
                    {
                        //add the item to basket table
                        basket.Quantity = 1;
                        await AddAsync(basket);
                    }
                }
                else
                {
                    //create user id for anynomus or add items to basket table
                    basket.Quantity = 1;
                    await AddAsync(basket);
                }
            }
            var totalItems = await GetBasketItems(basket.UserId, "");
            return totalItems.Count;
        }

        public async Task DeleteBasket(string userId, string productDetailId)
        {
            var basketList = await GetBasketItems(userId, productDetailId);
            foreach (var basket in basketList)
            {
                await DeleteAsync(basket);
            }
        }
       
        public async Task<List<BasketEnt>> GetBasket(string userId)
        {
            var basketList = await GetBasketItems(userId,"");
            return basketList;
        }

        private async Task<List<BasketEnt>> GetBasketItems(string userId, string productDetailId)
        {
            List<BasketEnt> basketList;

            if (!string.IsNullOrEmpty(productDetailId))
            {
                int res;
                basketList = await _dbContext.Basket
                   .Where(q => q.UserId == userId && q.ProductDetailId == (int.TryParse(productDetailId, out res) ? res : 0))
                   .ToListAsync();
            }
            else
            {
                basketList = await _dbContext.Basket
                   .Where(q => q.UserId == userId)
                   .ToListAsync();
            }

            return basketList;

        }

      public async Task CheckoutBasket(BasketCheckout basket)
        {
            _dbContext.Set<BasketCheckout>().Add(basket);
            await _dbContext.SaveChangesAsync();

            //await _dbContext.AddAsync<BasketCheckout>(basket);
            //_dbContext.SaveChanges();
            // await AddAsync(basket);
        }

        public async Task BookItemsForCheckount(BookItemsForCheckOut basket)
        {
            await _dbContext.Set<BookItemsForCheckOut>().AddAsync(basket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RollBackItemsForCheckount(BookItemsForCheckOut basket)
        {
             _dbContext.Set<BookItemsForCheckOut>().Remove(basket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookItemsForCheckOut>> GetItemsForCheckount(string userid)
        {
            var bookedItesm = await _dbContext.BookItemsForCheckOut
                                    .Where(q => q.UserId == userid)
                                    .ToListAsync();
                                    
            return bookedItesm;
        }

        public async Task SaveBookingHistory(BookingHistory hostory)
        {
            _dbContext.Set<BookingHistory>().Add(hostory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookItemsForCheckount(string userid)
        {
            var bookeditesm = await _dbContext.BookItemsForCheckOut.Where(q => q.UserId == userid).ToListAsync();
            _dbContext.Set<BookItemsForCheckOut>().RemoveRange(bookeditesm);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BookingHistory>> GetOrderHistory(string orderid)
        {
            var bookingHistory = await _dbContext.BookingHistory
                .Where(q => q.CheckOutId == Convert.ToInt32(orderid)).ToListAsync<BookingHistory>();
            return bookingHistory;
        }

        public async Task<List<BasketCheckout>> GetUserOrders(string userId)
        {
            var bookingHistory = await _dbContext.BasketCheckOut
                .Where(q => q.UserId == userId).ToListAsync<BasketCheckout>();
            return bookingHistory;
        }

        public async Task UpdateBasketUserId(string userguid, string userid)
        {
            var basketuser = await _dbContext.Basket.
                Where(q => q.UserId == userguid).ToListAsync();
            basketuser
                .ForEach(x => { x.UserId = userid; });

            _dbContext.UpdateRange(basketuser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
