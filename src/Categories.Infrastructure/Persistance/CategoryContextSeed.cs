using Microsoft.Extensions.Logging;
using Categories.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Categories.Domain.Entites;


namespace Categories.Infrastructure.Persistance
{
   public class CategoryContextSeed
    {
        public static async Task SeedAsync(CategoryContext categoryContext, ILogger<CategoryContextSeed> logger)
        {
            if (!categoryContext.Category.Any())
            {
                categoryContext.Category.AddRange(GetPreconfiguredCategories());
                await categoryContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(CategoryContext).Name);
            }
        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>
            {
                new Category() {CategoryName = "Cat Name1", CategoryDescr = "Cat - 1 desc", CategoryParent=0}
            };
        }
    }
}
