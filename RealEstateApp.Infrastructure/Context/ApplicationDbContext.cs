using MongoDB.Driver;
using RealEstateApp.Domain.Models;

namespace RealEstateApp.Infrastructure.Context
{
    public class ApplicationDbContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Property> Properties => _database.GetCollection<Property>("Properties");
        public IMongoCollection<Owner> Owners => _database.GetCollection<Owner>("Owners");
    }
}
