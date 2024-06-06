using Microsoft.EntityFrameworkCore;
using PostOfficeManagematAPI.Data;
using PostOfficeManagematAPI.Models.Domain;
using PostOfficeManagematAPI.Repositories.Interface;

namespace PostOfficeManagematAPI.Repositories.Implementation
{
    public class ParcelBagRepository : IParcelBagRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ParcelBagRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ParcelBag> CreateAsync(ParcelBag parcelBag)
        {
            await _dbContext.ParcelBags.AddAsync(parcelBag);
            await _dbContext.SaveChangesAsync();

            return parcelBag;
        }

        public async Task<List<ParcelBag>> GetAllAsync()
        {
            return await _dbContext.ParcelBags.ToListAsync();
        }

        public async Task<ParcelBag> GetByIdAsync(Guid id)
        {
            return await _dbContext.ParcelBags.FirstOrDefaultAsync(lb => lb.Id == id);
        }
    }
}
