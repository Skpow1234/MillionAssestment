using RealEstateApp.Domain.Models;

namespace RealEstateApp.Api.Application
{
    public interface IPropertyService
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice);
        Task<Property?> GetPropertyByIdAsync(string id);
        Task AddPropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(string id);
    }
}
