﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model.DTO.UpdateRegionDTOs
{
    public class UpdateRegion_DTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters.")]
        [MaxLength(3, ErrorMessage = "Code has to be a minimum of 3 characters.")]
        public string Code { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Name has to be a maximum of 50 characters.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
