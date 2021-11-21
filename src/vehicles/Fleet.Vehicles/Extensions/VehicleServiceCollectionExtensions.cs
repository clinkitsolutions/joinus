using Fleet.Vehicles;
using Fleet.Vehicles.Models;
using Fleet.Vehicles.Repositories;
using Fleet.Vehicles.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class VehicleServiceCollectionExtensions
    {
        public static IServiceCollection AddVehicleService(this IServiceCollection services, IConfiguration configuration, Assembly containingAssembly)
        {
            services.Configure<VehicleDbContextOptions>(configuration);
            services.AddDbContext<VehicleDbContext>((serviceProvider, options) =>
            {
                var config = serviceProvider.GetRequiredService<IOptions<VehicleDbContextOptions>>();
                options.UseSqlite(config.Value.ConnectionString, sqliteOptions =>
                {
                    sqliteOptions.MigrationsAssembly(containingAssembly.FullName);
                });
            });

            services.AddScoped<IVehicleRepository, EfCoreVehicleRepository>();
            services.AddScoped<IVehicleLogItemRepository, EfCoreVehicleLogItemRepository>();
            services.AddScoped<IFleetRepository, EfCoreFleetRepository>();

            services.AddScoped<IVehicleService, DefaultVehicleService>();
            services.AddScoped<IFleetService, DefaultFleetService>();

            return services;
        }
    }
}
