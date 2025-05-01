using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Categories.Infrastructure.Persistance;
using Categories.Infrastructure.Repository;
using Categories.Application.Persistance;
using System;

namespace Categories.Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static IServiceCollection AddCategoriesInfraServices(this IServiceCollection services,
           IConfiguration configuration)
        {

           Console.WriteLine(configuration.GetConnectionString("ProdductsConnectionString"));
            services.AddDbContext<CategoryContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("ProdductsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
