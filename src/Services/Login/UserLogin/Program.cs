using Login.API.Extensions;
using Login.Infrastructure.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace UserLogin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                        .ExecuteDbSeed<LoginContext>((context, services) =>
                        {
                            var logger = services.GetService<ILogger<LoginContextSeed>>();
                            LoginContextSeed
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
