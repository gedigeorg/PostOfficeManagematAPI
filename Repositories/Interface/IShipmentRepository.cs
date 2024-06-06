using PostOfficeManagematAPI.Models.Domain;

namespace PostOfficeManagematAPI.Repositories.Interface
{
    public interface IShipmentRepository
    {
        Task<Shipment> CreateAsync(Shipment shipment);
        Task<List<Shipment>> GetAllAsync();
        Task<Shipment> GetByIdAsync(Guid id);
        Task<Shipment> UpdateAsync(Shipment shipment);
    }
}
