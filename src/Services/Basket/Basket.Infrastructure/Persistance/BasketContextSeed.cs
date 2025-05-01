using Microsoft.Extensions.Logging;
using Basket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Domain.Entities;

namespace Basket.Infrastructure.Persistance
{
   public class BasketContextSeed
    {
        public static async Task SeedAsync(BasketContext basketContext, ILogger<BasketContextSeed> logger)
        {
            if (!basketContext.Basket.Any())
            {
                basketContext.Basket.AddRange(GetPreconfiguredCategories());
                await basketContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(BasketContext).Name);
            }
        }

        private static IEnumerable<BasketEnt> GetPreconfiguredCategories()
        {
            return new List<BasketEnt>
            {
                new BasketEnt() {UserId = "1", ProductDetailId = 1,Quantity=3}
            };
        }
    }
}
