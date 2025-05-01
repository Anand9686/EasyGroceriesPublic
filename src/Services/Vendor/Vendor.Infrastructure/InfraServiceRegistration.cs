using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vendor.Infrastructure.Persistance;
using Vendor.Infrastructure.Repository;
using Vendor.Application.Persistance;
using System;

namespace Vendor.Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static IServiceCollection AddVendorInfraServices(this IServiceCollection services,
           IConfiguration configuration)
        {

           Console.WriteLine(configuration.GetConnectionString("ProdductsConnectionString"));
            services.AddDbContext<VendorContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("ProdductsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IVendorRepository, VendorRepository>();

            return services;
        }
    }
}
