using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Configurations;

namespace Application.Configurations;

/// <summary>
/// The configuration extensions services.
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Adds the application module services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceServices(configuration);
        services.AddScopedService();        

        return services;
    }

    /// <summary>
    /// Adds the scoped service.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns></returns>
    private static IServiceCollection AddScopedService(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services;
    }

    /// <summary>
    /// Initializes the database.
    /// </summary>
    /// <param name="serviceScope">The service scope.</param>
    public static void InitializeDatabase(this IServiceScope serviceScope)
    {
        serviceScope.EnsureDatabase();
    }
}
