using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;

namespace NZWalks.API.Repositories.Interfaces
{
    public interface IWalkRepository
    {
        Task<Walk> AddWalkAsync(Walk walk);

        Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);

        Task<Walk?> GetWalkByIdAsync(Guid id);

        Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk);

        Task<Walk> DeleteByIdAsync(Guid id);
    }
}
