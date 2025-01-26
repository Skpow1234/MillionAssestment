using RealEstateApp.Domain.Models;
using RealEstateApp.Infrastructure;

namespace RealEstateApp.Api.Application
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<Property>> GetAllPropertiesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice)
        {
            return await _propertyRepository.GetPropertiesAsync(name, address, minPrice, maxPrice);
        }

        public async Task<Property?> GetPropertyByIdAsync(string id)
        {
            return await _propertyRepository.GetPropertyByIdAsync(id);
        }

        public async Task AddPropertyAsync(Property property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            await _propertyRepository.AddPropertyAsync(property);
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            var existingProperty = await _propertyRepository.GetPropertyByIdAsync(property.Id);
            if (existingProperty == null)
                throw new KeyNotFoundException($"Property with ID '{property.Id}' not found.");

            await _propertyRepository.UpdatePropertyAsync(property);
        }

        public async Task DeletePropertyAsync(string id)
        {
            var existingProperty = await _propertyRepository.GetPropertyByIdAsync(id);
            if (existingProperty == null)
                throw new KeyNotFoundException($"Property with ID '{id}' not found.");

            await _propertyRepository.DeletePropertyAsync(id);
        }
    }
}
