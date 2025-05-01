using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Utils.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Utils.API.Extensions;
using Microsoft.AspNetCore.Hosting;

namespace Utils.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                  .ExecuteDbSeed<UtilsContext>((context, services) =>
                  {
                      var logger = services.GetService<ILogger<UtilsContextSeed>>();
                      UtilsContextSeed
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
