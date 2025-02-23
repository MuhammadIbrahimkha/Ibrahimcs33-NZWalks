﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model.DTO.AddRegionDTOs
{
    public class AddRegionRequest_DTO
    {
        // Model Validation 

        [Required]
        // Code will always be three characters. When this validation is not met so we can also keep the custom error message.

        [MinLength(3,ErrorMessage = "Code has to be a minimum of 3 characters.")]
        [MaxLength(3,ErrorMessage = "Code has to be a maximum of 3 characters.")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Name has to be a maximum of 50 characters.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
