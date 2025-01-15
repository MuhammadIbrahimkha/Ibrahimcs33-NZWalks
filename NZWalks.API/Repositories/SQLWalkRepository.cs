using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<Walk> DeleteByIdAsync(Guid id)
        {
           var find =  await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(find == null)
            {
                return null;
            }

            _dbContext.Walks.Remove(find);

        await _dbContext.SaveChangesAsync();

            return find;
            
        
        }

       

        public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks = _dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // Filtering
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));

                }
            }

            // Sorting

            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x  => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if(sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            // Pagenation.

            var skipResult = (pageNumber - 1) * pageSize;

             
            return await walks.Skip(skipResult).Take(pageSize).ToListAsync();

            // I've broken the following line of code into two separate above lines.
         //  return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

            // What the 'Include' method does is it does, before returning the List we've also need the information of the 'Difficulty', and the 'Region'.
        }

       

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
          return await _dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);

            
        }

        public async Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk)
        {
           var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingWalk == null)
            {
                return null;
            }


            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
