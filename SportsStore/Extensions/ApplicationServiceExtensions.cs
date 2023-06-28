using Microsoft.EntityFrameworkCore;
using SportsStore.Application.Services;
using SportsStore.Data;
using SportsStore.Persistance.Interfaces;
using SportsStore.Persistance.Repositories;

namespace SportsStore.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreDbContext>(opts =>
            {
                opts.UseSqlServer(config["ConnectionStrings:SportsStoreConnection"]);
            });

            return services;
        }

        public static IServiceCollection AddDependenciesService(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
