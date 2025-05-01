using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Domain.Entities;

namespace Utils.Infrastructure.Persistance
{
    public class UtilsContextSeed
    {
        public static async Task SeedAsync(UtilsContext utilsContext, ILogger<UtilsContextSeed> logger)
        {
            if (!utilsContext.Unit.Any())
            {
                utilsContext.Unit.AddRange(GetPreconfiguredUnit());
                await utilsContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(UtilsContext).Name);
            }
        }

        private static IEnumerable<Unit> GetPreconfiguredUnit()
        {
            return new List<Unit>
            {
                new Unit() {UnitCode = "U001", UnitName = "KG"},
                new Unit() {UnitCode = "U002", UnitName = "Liter"}
            };
        }
    }
}
