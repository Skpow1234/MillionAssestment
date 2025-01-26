using Moq;
using Xunit;
using RealEstateApp.Api.Application;
using RealEstateApp.Domain.Models;
using RealEstateApp.Infrastructure;

namespace RealEstateApp.Tests.UnitTests.Services
{
    public class PropertyServiceTests
    {
        private readonly Mock<IPropertyRepository> _propertyRepositoryMock;
        private readonly PropertyService _propertyService;

        public PropertyServiceTests()
        {
            _propertyRepositoryMock = new Mock<IPropertyRepository>();
            _propertyService = new PropertyService(_propertyRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllPropertiesAsync_ShouldReturnProperties_WhenCalled()
        {
            var properties = new List<Property>
            {
                new Property
                {
                    Id = "1",
                    Name = "House 1",
                    Price = 500000,
                    Address = "123 Main St",
                    IdOwner = "Owner1",
                    ImageUrl = "http://example.com/house1.jpg"
                },
                new Property
                {
                    Id = "2",
                    Name = "House 2",
                    Price = 750000,
                    Address = "456 Elm St",
                    IdOwner = "Owner2",
                    ImageUrl = "http://example.com/house2.jpg"
                }
            };
            _propertyRepositoryMock.Setup(repo => repo.GetPropertiesAsync(null, null, null, null))
                                .ReturnsAsync(properties);

            var result = await _propertyService.GetAllPropertiesAsync(null, null, null, null);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetPropertyByIdAsync_ShouldReturnProperty_WhenPropertyExists()
        {
            var property = new Property
            {
                Id = "1",
                Name = "House 1",
                Price = 500000,
                Address = "123 Main St",
                IdOwner = "Owner1",
                ImageUrl = "http://example.com/house1.jpg"
            };
            _propertyRepositoryMock.Setup(repo => repo.GetPropertyByIdAsync("1"))
                                .ReturnsAsync(property);

            var result = await _propertyService.GetPropertyByIdAsync("1");

            Assert.NotNull(result);
            Assert.Equal("House 1", result?.Name);
        }

        [Fact]
        public async Task AddPropertyAsync_ShouldCallRepository_WhenPropertyIsValid()
        {
            var property = new Property
            {
                Id = "3",
                Name = "New House",
                Price = 300000,
                Address = "789 Pine St",
                IdOwner = "Owner3",
                ImageUrl = "http://example.com/house3.jpg"
            };

            await _propertyService.AddPropertyAsync(property);

            _propertyRepositoryMock.Verify(repo => repo.AddPropertyAsync(property), Times.Once);
        }

        [Fact]
        public async Task UpdatePropertyAsync_ShouldCallRepository_WhenPropertyExists()
        {
            var property = new Property
            {
                Id = "1",
                Name = "Updated House",
                Price = 600000,
                Address = "123 Updated St",
                IdOwner = "Owner1",
                ImageUrl = "http://example.com/updatedhouse.jpg"
            };

            _propertyRepositoryMock.Setup(repo => repo.GetPropertyByIdAsync(property.Id))
                                .ReturnsAsync(property);

            await _propertyService.UpdatePropertyAsync(property);

            _propertyRepositoryMock.Verify(repo => repo.UpdatePropertyAsync(property), Times.Once);
        }

        [Fact]
        public async Task UpdatePropertyAsync_ShouldThrowException_WhenPropertyDoesNotExist()
        {
            var property = new Property
            {
                Id = "99",
                Name = "Nonexistent House",
                Price = 100000,
                Address = "Nonexistent Address",
                IdOwner = "Owner99",
                ImageUrl = "http://example.com/nonexistent.jpg"
            };

            _propertyRepositoryMock.Setup(repo => repo.GetPropertyByIdAsync(property.Id))
                                .ReturnsAsync((Property?)null);

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _propertyService.UpdatePropertyAsync(property));
        }

        [Fact]
        public async Task DeletePropertyAsync_ShouldCallRepository_WhenPropertyExists()
        {
            var property = new Property
            {
                Id = "1",
                Name = "House to Delete",
                Price = 500000,
                Address = "123 Main St",
                IdOwner = "Owner1",
                ImageUrl = "http://example.com/deletehouse.jpg"
            };

            _propertyRepositoryMock.Setup(repo => repo.GetPropertyByIdAsync(property.Id))
                                .ReturnsAsync(property);

            await _propertyService.DeletePropertyAsync(property.Id);

            _propertyRepositoryMock.Verify(repo => repo.DeletePropertyAsync(property.Id), Times.Once);
        }

        [Fact]
        public async Task DeletePropertyAsync_ShouldThrowException_WhenPropertyDoesNotExist()
        {
            _propertyRepositoryMock.Setup(repo => repo.GetPropertyByIdAsync("99"))
                                .ReturnsAsync((Property?)null);

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _propertyService.DeletePropertyAsync("99"));
        }
    }
}
