using Microsoft.Extensions.Logging;
using Products.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Domain.Entites;


namespace Products.Infrastructure.Persistance
{
   public class ProductContextSeed
    {
        public static async Task SeedAsync(ProductContext productContext, ILogger<ProductContextSeed> logger)
        {
            if (!productContext.Product.Any())
            {
                productContext.Product.AddRange(GetPreconfiguredProducts());
                await productContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ProductContext).Name);
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product() {Name = "Oil", Description = "Edible Ile", Units = "1 Liter", Price = 100.50, StockCount = 20, ReorderLevel = 5, Discount=0.2, Flag=true, DiscountValidDate = new DateTime(2023,3,3), ImageName="test.jpg"}
            };
        }
    }
}
