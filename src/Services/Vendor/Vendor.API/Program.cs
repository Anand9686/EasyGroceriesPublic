using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vendor.API.Extensions;
using Vendor.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Vendor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                 .ExecuteDbSeed<VendorContext>((context, services) =>
                 {
                     var logger = services.GetService<ILogger<VendorContextSeed>>();
                     VendorContextSeed
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
