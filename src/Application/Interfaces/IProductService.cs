using Application.Models;

namespace Application.Interfaces;

/// <summary>
/// Product Service interface.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<List<ProductDto>> GetAllAsync();

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="Id">The identifier.</param>
    /// <returns></returns>
    Task<ProductDto> GetByIdAsync(int Id);
}

