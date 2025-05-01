using Microsoft.Extensions.Logging;
using Vendor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.Domain.Entites;


namespace Vendor.Infrastructure.Persistance
{
   public class VendorContextSeed
    {
        public static async Task SeedAsync(VendorContext vendorContext, ILogger<VendorContextSeed> logger)
        {
            if (!vendorContext.Vendor.Any())
            {
                vendorContext.Vendor.AddRange(GetPreconfiguredCategories());
                await vendorContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(VendorContext).Name);
            }
        }

        private static IEnumerable<VendorInfo> GetPreconfiguredCategories()
        {
            return new List<VendorInfo>
            {
                new VendorInfo() {Name = "Vendor 1", Address = "Vendor -BasavanaGudi", Email="vendor@gmail.com", Mobile ="+919988776654"}
            };
        }
    }
}
