using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Persistance;
using Products.Infrastructure.Persistance;
using Products.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static IServiceCollection AddProductsInfraServices(this IServiceCollection services,
           IConfiguration configuration)
        {

           Console.WriteLine(configuration.GetConnectionString("ProdductsConnectionString"));
            services.AddDbContext<ProductContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("ProdductsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
