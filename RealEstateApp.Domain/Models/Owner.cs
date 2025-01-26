namespace RealEstateApp.Domain.Models
{
    public class Owner
    {
        public required string Id { get; set; } // Unique identifier for the owner
        public required string Name { get; set; } // Owner's name
        public required string Email { get; set; } // Owner's email
        public required string Phone { get; set; } // Owner's phone number
    }
}
