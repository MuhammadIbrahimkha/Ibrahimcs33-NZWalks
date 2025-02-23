﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO.ImageUploadDTO;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }



        // POST: /api/Images/Upload

        [HttpPost]
        [Route("Upload")]

        public async Task<IActionResult> Upload([FromForm] ImageUploadRequest_Dto request)
        {
            ValidateFileUpload(request);

            if(ModelState.IsValid)
            {
                // Convert DTO to Domain Model

                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,

                };

                // User repository to upload image.
                await imageRepository.Upload(imageDomainModel);
                return Ok(imageDomainModel);


            }

            return BadRequest(ModelState);
        }


        private void ValidateFileUpload(ImageUploadRequest_Dto uploadRequest)
        {
            var allowedExtensions = new string[]
            {
               ".jpg",".jpeg",".png"


            };

            if(!allowedExtensions.Contains(Path.GetExtension(uploadRequest.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension.");
            }

            if(uploadRequest.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size is more than 10MB, please upload a smaller size file.");
            }
        }
    }
}
