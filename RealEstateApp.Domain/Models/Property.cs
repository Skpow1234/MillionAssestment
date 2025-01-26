namespace RealEstateApp.Domain.Models
{
    public class Property
    {
        public required string Id { get; set; } // Unique identifier for the property
        public required string IdOwner { get; set; } // Owner's ID
        public required string Name { get; set; } // Name of the property
        public required string Address { get; set; } // Property address
        public decimal Price { get; set; } // Property price
        public required string ImageUrl { get; set; } // URL for the property's image
    }
}
