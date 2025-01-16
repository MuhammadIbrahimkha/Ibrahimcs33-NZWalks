using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model.DTO.ImageUploadDTO
{
    public class ImageUploadRequest_Dto
    {
        [Required]
        public IFormFile File { get; set; }
        
        [Required]
        public string FileName { get; set; }


        public string? FileDescription { get; set; }


    }
}
