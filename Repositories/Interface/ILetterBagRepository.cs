using PostOfficeManagematAPI.Models.Domain;

namespace PostOfficeManagematAPI.Repositories.Interface
{
    public interface ILetterBagRepository
    {
        Task<LetterBag> CreateAsync(LetterBag letterBag);
        Task<List<LetterBag>> GetAllAsync();
        Task<LetterBag> GetByIdAsync(Guid id);
    }
}
