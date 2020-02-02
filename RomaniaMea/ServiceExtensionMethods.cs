using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RomaniaMea.Repositories;
using RomaniaMea.IRepositories;
using RomaniaMea.Interfaces;

namespace RomaniaMea
{
    public static class ServiceExtensionMethods
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config, string appName)
        {
            string connectionString = config["ConnectionStrings:connectionString"];
            services.AddDbContext<RepositoryContext>(c => c.UseSqlServer(connectionString, 
                b => b.MigrationsAssembly(appName)));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        }
    }
}
