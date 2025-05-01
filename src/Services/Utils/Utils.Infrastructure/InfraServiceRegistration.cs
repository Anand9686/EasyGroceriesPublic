using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Application.Contracts.Persistance;
using Utils.Infrastructure.Persistance;
using Utils.Infrastructure.Repository;

namespace Utils.Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static IServiceCollection AddProductsInfraServices(this IServiceCollection services,
          IConfiguration configuration)
        {

            Console.WriteLine(configuration.GetConnectionString("ProdductsConnectionString"));
            services.AddDbContext<UtilsContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("ProdductsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IUtilsRepository, UtilsRepository>();

            return services;
        }
    }
}
