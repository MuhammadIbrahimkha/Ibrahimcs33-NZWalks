using NZWalks.API.Data;
using NZWalks.API.Model.Domain;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly NZWalksDbContext _nZWalksDb;
        private readonly IHttpContextAccessor _contextAccessor;

        public LocalImageRepository(IWebHostEnvironment webHost, IHttpContextAccessor contextAccessor, NZWalksDbContext nZWalksDb)
        {
            _webHost = webHost;
            _nZWalksDb = nZWalksDb;
            _contextAccessor = contextAccessor;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(_webHost.ContentRootPath,"Images",
                $"{image.FileName}{image.FileExtension}");

            // Upload Image to local path.
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // https://localhost:1234/images/image.jpg


            var urlFilePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            
            image.FilePath = urlFilePath;

            // Add Image to the Images folder
            
            await _nZWalksDb.Images.AddAsync(image);
            await _nZWalksDb.SaveChangesAsync();
            
            return image;
        }
    }
}
