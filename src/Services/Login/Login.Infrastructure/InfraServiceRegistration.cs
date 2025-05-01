using Login.Application.Persistance;
using Login.Infrastructure.Persistance;
using Login.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Login.Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static IServiceCollection AddLoginInfraServices(this IServiceCollection services,
           IConfiguration configuration)
        {

            Console.WriteLine(configuration.GetConnectionString("ProdductsConnectionString"));
            services.AddDbContext<LoginContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("ProdductsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ILoginRepository, LoginRepository>();

            return services;
        }
    }
}
