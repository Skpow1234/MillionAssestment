using Microsoft.Extensions.DependencyInjection;
using RealEstateApp.Infrastructure.Context;

namespace RealEstateApp.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
                new ApplicationDbContext("YourMongoDBConnectionString", "YourDatabaseName"));
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            return services;
        }
    }
}
