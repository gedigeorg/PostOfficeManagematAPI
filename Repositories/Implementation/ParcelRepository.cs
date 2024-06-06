using Microsoft.EntityFrameworkCore;
using PostOfficeManagematAPI.Data;
using PostOfficeManagematAPI.Models.Domain;
using PostOfficeManagematAPI.Repositories.Interface;

namespace PostOfficeManagematAPI.Repositories.Implementation
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ParcelRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Parcel> CreateAsync(Parcel parcel)
        {
            await _dbContext.Parcels.AddAsync(parcel);
            await _dbContext.SaveChangesAsync();

            return parcel;
        }

        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _dbContext.Parcels.ToListAsync();
        }

        public async Task<Parcel> GetByIdAsync(Guid id)
        {
            return await _dbContext.Parcels.FirstOrDefaultAsync(lb => lb.Id == id);
        }
    }
}
