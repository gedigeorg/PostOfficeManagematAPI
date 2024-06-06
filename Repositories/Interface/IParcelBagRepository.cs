using PostOfficeManagematAPI.Models.Domain;

namespace PostOfficeManagematAPI.Repositories.Interface
{
    public interface IParcelBagRepository
    {
        Task<ParcelBag> CreateAsync(ParcelBag parcelBag);
        Task<List<ParcelBag>> GetAllAsync();
        Task<ParcelBag> GetByIdAsync(Guid id);
    }
}
