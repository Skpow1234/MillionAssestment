using RealEstateApp.Domain.Models;

namespace RealEstateApp.Infrastructure
{
    public interface IOwnerRepository
    {
        Task<Owner?> GetOwnerByIdAsync(string id);
        Task AddOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner owner);
        Task DeleteOwnerAsync(string id);
    }
}
