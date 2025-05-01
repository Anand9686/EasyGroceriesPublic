using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Basket.Infrastructure.Repository;
using Basket.Application.Persistance;
using System;
using Basket.Infrastructure.Persistance;

namespace Basket.Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static IServiceCollection AddCategoriesInfraServices(this IServiceCollection services,
           IConfiguration configuration)
        {

           Console.WriteLine(configuration.GetConnectionString("ProdductsConnectionString"));
            services.AddDbContext<BasketContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("ProdductsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IBasketRepository, BasketRepository>();

            return services;
        }
    }
}