using PostOfficeManagematAPI.Models.Domain;

namespace PostOfficeManagematAPI.Repositories.Interface
{
    public interface IParcelRepository
    {
        Task<Parcel> CreateAsync(Parcel parcel);
        Task<List<Parcel>> GetAllAsync();
        Task<Parcel> GetByIdAsync(Guid id);
    }
}
