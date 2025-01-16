using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
