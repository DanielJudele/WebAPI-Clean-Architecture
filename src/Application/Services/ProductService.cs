using Application.Interfaces;
using Application.Mappings;
using Application.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;

namespace Application.Services;

public class ProductService : IProductService
{
    /// <summary>
    /// The mapper
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Gets the services.
    /// </summary>
    /// <value>
    /// The services.
    /// </value>
    protected IServiceProvider Services { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductService"/> class.
    /// </summary>
    /// <param name="mapper">The mapper.</param>
    /// <param name="services">The services.</param>
    public ProductService(IMapper mapper, IServiceProvider services)
    {
        _mapper = mapper;
        Services = services;

        // Add specific _mapper profile
        var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });

        this._mapper = new Mapper(mapperConfig);
    }

    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<List<ProductDto>> GetAllAsync()
    {
        var productRepository = this.Services.GetRequiredService<IProductRepository>();
        var products = await productRepository.GetAllAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="Id">The identifier.</param>
    /// <returns></returns>
    public async Task<ProductDto> GetByIdAsync(int Id)
    {
        var productRepository = this.Services.GetRequiredService<IProductRepository>();
        var product = await productRepository.GetByIdAsync(Id);
        return _mapper.Map<ProductDto>(product);
    }
}
