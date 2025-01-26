using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Api.Application;
using RealEstateApp.Domain.Models;

namespace RealEstateApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // GET: /api/properties
        [HttpGet]
        public async Task<IActionResult> GetAllProperties([FromQuery] string? name, [FromQuery] string? address, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var properties = await _propertyService.GetAllPropertiesAsync(name, address, minPrice, maxPrice);
            return Ok(properties);
        }

        // GET: /api/properties/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(string id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
                return NotFound();
            return Ok(property);
        }

        // POST: /api/properties
        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromBody] Property newProperty)
        {
            if (newProperty == null)
                return BadRequest("Property data is required.");

            await _propertyService.AddPropertyAsync(newProperty);
            return CreatedAtAction(nameof(GetPropertyById), new { id = newProperty.Id }, newProperty);
        }

        // PUT: /api/properties/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(string id, [FromBody] Property updatedProperty)
        {
            if (updatedProperty == null || updatedProperty.Id != id)
                return BadRequest("Invalid property data.");

            var existingProperty = await _propertyService.GetPropertyByIdAsync(id);
            if (existingProperty == null)
                return NotFound();

            await _propertyService.UpdatePropertyAsync(updatedProperty);
            return NoContent();
        }

        // DELETE: /api/properties/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(string id)
        {
            var existingProperty = await _propertyService.GetPropertyByIdAsync(id);
            if (existingProperty == null)
                return NotFound();

            await _propertyService.DeletePropertyAsync(id);
            return NoContent();
        }
    }
}
