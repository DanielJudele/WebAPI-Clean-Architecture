using Application.Interfaces;
using Application.Models;
using AutoFixture;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace WebAPI.Tests
{
    
    public class ProductsControllerTests
    {
        private Mock<IServiceProvider> MockServiceProvider;
        private Mock<IProductService> MockMyService;

        public ProductsControllerTests()
        {
            MockServiceProvider = new Mock<IServiceProvider>();
            MockMyService = new Mock<IProductService>();
        }

        [Fact]
        public async Task GetAll_Returns_OkResult()
        {

            //Arrange
            var fixture = new Fixture();
            var sampleData = new List<ProductDto>
            {
                fixture.Create<ProductDto>(),
                fixture.Create<ProductDto>(),
            };

            MockMyService.Setup(service => service.GetAllAsync()).ReturnsAsync(sampleData);
            MockServiceProvider
                .Setup(provider => provider.GetService(typeof(IProductService)))
                .Returns(MockMyService.Object);


            var productsController = new ProductsController(MockServiceProvider.Object);

            //Act
            var result = await productsController.GetAll();

            // Assert
            MockMyService.Verify(s => s.GetAllAsync());
            Assert.IsType<OkObjectResult>(result);
        }
    }
}