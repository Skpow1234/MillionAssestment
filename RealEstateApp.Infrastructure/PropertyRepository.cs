using MongoDB.Driver;
using RealEstateApp.Domain.Models;
using RealEstateApp.Infrastructure.Context;

namespace RealEstateApp.Infrastructure
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice)
        {
            var filterBuilder = Builders<Property>.Filter;
            var filters = new List<FilterDefinition<Property>>();

            if (!string.IsNullOrEmpty(name))
                filters.Add(filterBuilder.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(name, "i")));
            if (!string.IsNullOrEmpty(address))
                filters.Add(filterBuilder.Regex(p => p.Address, new MongoDB.Bson.BsonRegularExpression(address, "i")));
            if (minPrice.HasValue)
                filters.Add(filterBuilder.Gte(p => p.Price, minPrice.Value));
            if (maxPrice.HasValue)
                filters.Add(filterBuilder.Lte(p => p.Price, maxPrice.Value));

            var filter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

            return await _context.Properties.Find(filter).ToListAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(string id)
        {
            return await _context.Properties.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddPropertyAsync(Property property)
        {
            await _context.Properties.InsertOneAsync(property);
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            await _context.Properties.ReplaceOneAsync(p => p.Id == property.Id, property);
        }

        public async Task DeletePropertyAsync(string id)
        {
            await _context.Properties.DeleteOneAsync(p => p.Id == id);
        }
    }
}
