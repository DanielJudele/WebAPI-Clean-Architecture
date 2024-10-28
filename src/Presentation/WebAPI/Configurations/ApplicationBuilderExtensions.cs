using Application.Configurations;

namespace WebAPI.Configurations;

/// <summary>
/// Application builder extensions.
/// </summary>
internal static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Uses the database.
    /// </summary>
    /// <param name="app">The application.</param>
    /// <param name="environment">The environment.</param>
    internal static void UseDatabase(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        serviceScope.InitializeDatabase();
    }
}
