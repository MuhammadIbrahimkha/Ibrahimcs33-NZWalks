using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Model.Domain;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<Walk> AddWalkAsync(Walk walk)
        {
           await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
           return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

            // What the 'Include' method does is it does, before returning the List we've also need the information of the 'Difficulty', and the 'Region'.
        }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
          return await _dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);

            
        }
    }
}
