using Categories.API.Extensions;
using Categories.Infrastructure.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Categories.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                 .ExecuteDbSeed<CategoryContext>((context, services) =>
                 {
                     var logger = services.GetService<ILogger<CategoryContextSeed>>();
                     CategoryContextSeed
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
