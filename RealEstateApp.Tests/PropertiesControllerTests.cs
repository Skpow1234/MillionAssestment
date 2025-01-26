using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Api.Controllers;
using RealEstateApp.Api.Application;
using RealEstateApp.Domain.Models;

namespace RealEstateApp.Tests.UnitTests.Controllers
{
    public class PropertiesControllerTests
    {
        private readonly Mock<IPropertyService> _propertyServiceMock;
        private readonly PropertiesController _controller;

        public PropertiesControllerTests()
        {
            _propertyServiceMock = new Mock<IPropertyService>();
            _controller = new PropertiesController(_propertyServiceMock.Object);
        }

        [Fact]
        public async Task GetAllProperties_ShouldReturnOk_WhenPropertiesExist()
        {
            var properties = new List<Property>
            {
                new Property { Id = "1", Name = "House 1", Price = 500000, Address = "123 Main St", IdOwner = "Owner1", ImageUrl = "http://example.com/image1.jpg" },
                new Property { Id = "2", Name = "House 2", Price = 750000, Address = "456 Elm St", IdOwner = "Owner2", ImageUrl = "http://example.com/image2.jpg" }
            };
            _propertyServiceMock.Setup(service => service.GetAllPropertiesAsync(null, null, null, null))
                                .ReturnsAsync(properties);


            var result = await _controller.GetAllProperties(null, null, null, null);


            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProperties = Assert.IsAssignableFrom<IEnumerable<Property>>(okResult.Value);
            Assert.Equal(2, returnedProperties.Count());
        }

        [Fact]
        public async Task GetPropertyById_ShouldReturnNotFound_WhenPropertyDoesNotExist()
        {
            _propertyServiceMock.Setup(service => service.GetPropertyByIdAsync("1"))
                                .ReturnsAsync((Property?)null);

            var result = await _controller.GetPropertyById("1");

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
