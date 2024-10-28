using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;
using Persistence.Repositories;

namespace Persistence.Configurations;

/// <summary>
/// Configuration extensions.
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// The database context options builder
    /// </summary>
    private static DbContextOptionsBuilder<ApplicationDbContext>? dbContextOptionsBuilder;

    /// <summary>
    /// Adds the persistence services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns></returns>
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextService(configuration);
        services.AddScopedService();

        return services;
    }

    /// <summary>
    /// Adds the database context service.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns></returns>
    private static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseSqlServer(connectionString);
        services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(connectionString), ServiceLifetime.Transient);

        return services;
    }

    /// <summary>
    /// Adds the scoped service.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns></returns>
    private static IServiceCollection AddScopedService(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

    /// <summary>
    /// Ensures the database.
    /// </summary>
    /// <param name="serviceScope">The service scope.</param>
    public static void EnsureDatabase(this IServiceScope serviceScope)
    {
        using var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}
