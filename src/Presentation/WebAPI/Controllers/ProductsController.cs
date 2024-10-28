using Application.Interfaces;
using Application.Models;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        protected IServiceProvider Services { get; }

        public ProductsController(IServiceProvider services)
        {
            this.Services = services;            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productService = this.Services.GetRequiredService<IProductService>();
            var productsDto = await productService.GetAllAsync();

            return Ok(productsDto);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var productService = this.Services.GetRequiredService<IProductService>();
            var productDto = await productService.GetByIdAsync(Id);

            if (productDto == null)
            {
                return NotFound();
            }

            return Ok(productDto);
        }
    }
}