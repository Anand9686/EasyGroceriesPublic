using Login.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Persistance
{
    public class LoginContextSeed
    {
        public static async Task SeedAsync(LoginContext loginContext, ILogger<LoginContextSeed> logger)
        {
            if (!loginContext.User.Any())
            {
                loginContext.User.AddRange(GetPreconfiguredCategories());
                await loginContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(LoginContextSeed).Name);
            }
        }

        private static IEnumerable<User> GetPreconfiguredCategories()
        {
            return new List<User>
            {
                new User() {Mobile = "9483941729", Name = "Suresh", Email="vendor@gmail.com", DOB = DateTime.UtcNow}
            };
        }
    }
}
