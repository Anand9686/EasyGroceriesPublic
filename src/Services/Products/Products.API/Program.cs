 using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Products.API.Extensions;
using Products.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Products.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                  .ExecuteDbSeed<ProductContext>((context, services) =>
                  {
                      var logger = services.GetService<ILogger<ProductContextSeed>>();
                      ProductContextSeed
                          .SeedAsync(context, logger)
                          .Wait();
                  })
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
