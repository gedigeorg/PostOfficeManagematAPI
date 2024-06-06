using Microsoft.EntityFrameworkCore;
using PostOfficeManagematAPI.Data;
using PostOfficeManagematAPI.Models.Domain;
using PostOfficeManagematAPI.Repositories.Interface;

namespace PostOfficeManagematAPI.Repositories.Implementation
{
    public class LetterBagRepository : ILetterBagRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LetterBagRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LetterBag> CreateAsync(LetterBag letterBag)
        {
            await _dbContext.LetterBags.AddAsync(letterBag);
            await _dbContext.SaveChangesAsync();

            return letterBag;
        }

        public async Task<List<LetterBag>> GetAllAsync()
        {
            return await _dbContext.LetterBags.ToListAsync();
        }

        public async Task<LetterBag> GetByIdAsync(Guid id)
        {
            return await _dbContext.LetterBags.FirstOrDefaultAsync(lb => lb.Id == id);
        }

        //public async Task<LetterBag> UpdateAsync(LetterBag letterBag)
        //{
        //    _dbContext.LetterBags.Update(letterBag);
        //    await _dbContext.SaveChangesAsync();
        //    return letterBag;
        //}

        //public async Task<bool> DeleteAsync(Guid id)
        //{
        //    var letterBag = await _dbContext.LetterBags.FirstOrDefaultAsync(lb => lb.Id == id);
        //    if (letterBag == null)
        //    {
        //        return false;
        //    }

        //    _dbContext.LetterBags.Remove(letterBag);
        //    await _dbContext.SaveChangesAsync();
        //    return true;
        //}
    }
}
