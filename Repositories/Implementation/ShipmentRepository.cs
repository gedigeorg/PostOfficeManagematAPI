using Microsoft.EntityFrameworkCore;
using PostOfficeManagematAPI.Data;
using PostOfficeManagematAPI.Models.Domain;
using PostOfficeManagematAPI.Repositories.Interface;

namespace PostOfficeManagematAPI.Repositories.Implementation
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShipmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Shipment> CreateAsync(Shipment shipment)
        {
            await _dbContext.Shipments.AddAsync(shipment);
            await _dbContext.SaveChangesAsync();

            return shipment;
        }

        public async Task<List<Shipment>> GetAllAsync()
        {
            return await _dbContext.Shipments.ToListAsync();
        }

        public async Task<Shipment> GetByIdAsync(Guid id)
        {
            return await _dbContext.Shipments.FirstOrDefaultAsync(lb => lb.Id == id);
        }

        public async Task<Shipment> UpdateAsync(Shipment shipment)
        {
            _dbContext.Shipments.Update(shipment);
            await _dbContext.SaveChangesAsync();
            return shipment;
        }


    }
}
