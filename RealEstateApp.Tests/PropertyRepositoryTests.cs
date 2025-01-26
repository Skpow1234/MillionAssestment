using Xunit;
using Moq;
using MongoDB.Driver;
using RealEstateApp.Domain.Models;
using RealEstateApp.Infrastructure;
using RealEstateApp.Infrastructure.Context;

namespace RealEstateApp.Tests.UnitTests.Repositories
{
    public class PropertyRepositoryTests
    {
        private readonly Mock<IMongoCollection<Property>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly Mock<IMongoClient> _mockClient;
        private readonly ApplicationDbContext _dbContext;
        private readonly PropertyRepository _repository;

        public PropertyRepositoryTests()
        {
            _mockCollection = new Mock<IMongoCollection<Property>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();

            _mockDatabase.Setup(db => db.GetCollection<Property>(It.IsAny<string>(), null))
                        .Returns(_mockCollection.Object);

            _mockClient.Setup(client => client.GetDatabase(It.IsAny<string>(), null))
                    .Returns(_mockDatabase.Object);

            _dbContext = new ApplicationDbContext("mongodb://localhost:27017", "TestDatabase");
            _repository = new PropertyRepository(_dbContext);
        }

        [Fact]
        public async Task GetPropertiesAsync_ShouldReturnMatchingProperties()
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
            var asyncCursor = new Mock<IAsyncCursor<Property>>();
            asyncCursor.Setup(cursor => cursor.Current).Returns(properties);
            asyncCursor.SetupSequence(cursor => cursor.MoveNext(It.IsAny<CancellationToken>())).Returns(true).Returns(false);

            _mockCollection.Setup(coll => coll.FindAsync(It.IsAny<FilterDefinition<Property>>(),
                                                        It.IsAny<FindOptions<Property, Property>>(),
                                                        It.IsAny<CancellationToken>()))
                        .ReturnsAsync(asyncCursor.Object);

            var result = await _repository.GetPropertiesAsync(null, null, null, null);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task UpdatePropertyAsync_ShouldUpdateProperty()
        {
            var property = new Property
            {
                Id = "1",
                Name = "Updated House",
                Price = 600000,
                Address = "789 Pine St",
                IdOwner = "Owner1",
                ImageUrl = "http://example.com/updated.jpg"
            };

            _mockCollection.Setup(coll => coll.ReplaceOneAsync(
                It.IsAny<FilterDefinition<Property>>(),
                property,
                It.IsAny<ReplaceOptions>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(new ReplaceOneResult.Acknowledged(1, 1, null));

            await _repository.UpdatePropertyAsync(property);

            _mockCollection.Verify(coll => coll.ReplaceOneAsync(
                It.IsAny<FilterDefinition<Property>>(),
                property,
                It.IsAny<ReplaceOptions>(),
                It.IsAny<CancellationToken>()
            ), Times.Once);
        }
    }
}
