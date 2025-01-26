using MongoDB.Driver;
using RealEstateApp.Domain.Models;
using RealEstateApp.Infrastructure.Context;

namespace RealEstateApp.Infrastructure
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Owner?> GetOwnerByIdAsync(string id)
        {
            return await _context.Owners.Find(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddOwnerAsync(Owner owner)
        {
            await _context.Owners.InsertOneAsync(owner);
        }

        public async Task UpdateOwnerAsync(Owner owner)
        {
            await _context.Owners.ReplaceOneAsync(o => o.Id == owner.Id, owner);
        }

        public async Task DeleteOwnerAsync(string id)
        {
            await _context.Owners.DeleteOneAsync(o => o.Id == id);
        }
    }
}
