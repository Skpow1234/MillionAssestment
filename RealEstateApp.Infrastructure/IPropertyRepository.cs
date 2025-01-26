using RealEstateApp.Domain.Models;

namespace RealEstateApp.Infrastructure
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice);
        Task<Property?> GetPropertyByIdAsync(string id);
        Task AddPropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(string id);
    }
}
