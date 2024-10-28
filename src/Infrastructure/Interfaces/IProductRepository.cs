using Domain.Entities;

namespace Persistence.Interfaces;

/// <summary>
/// Product repository interface.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<List<Product>> GetAllAsync();

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="Id">The identifier.</param>
    /// <returns></returns>
    Task<Product> GetByIdAsync(int Id);
}
