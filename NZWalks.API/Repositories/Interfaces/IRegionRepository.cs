using Microsoft.EntityFrameworkCore.Update.Internal;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        // we need five methods here

        // First: GetAllRegion 
        Task<List<Region>> GetAllAsync();

        // Second: GetById
        Task<Region?> GetByIdAsync(Guid id);

        // Third : Post

        Task<Region> AddRegionAsync(Region region);

        // Fourth: Delete

        Task<Region?> UpdateAsync(Guid id, Region region);

        // Fifth: Delete

        Task<Region?> DeleteRegionAsync(Guid id);
    }
}
