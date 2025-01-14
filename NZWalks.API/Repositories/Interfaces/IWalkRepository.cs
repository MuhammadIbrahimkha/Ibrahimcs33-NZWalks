using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;

namespace NZWalks.API.Repositories.Interfaces
{
    public interface IWalkRepository
    {
        Task<Walk> AddWalkAsync(Walk walk);

        Task<List<Walk>> GetAllWalksAsync();

        Task<Walk?> GetWalkByIdAsync(Guid id);

        Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk);

        Task<Walk> DeleteByIdAsync(Guid id);
    }
}
