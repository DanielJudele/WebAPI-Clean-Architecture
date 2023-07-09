using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private IProductRepository productRepository;
        private readonly IMapper mapper;


        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository, IMapper mapper)
        {
            this.logger = logger;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productRepository.GetAllAsync();
            var productsDto = mapper.Map<List<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var product = await productRepository.GetByIdAsync(Id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }
    }
}