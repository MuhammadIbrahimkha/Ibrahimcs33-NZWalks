using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model.DTO.UpdateRegionDTOs
{
    public class UpdateWalkRequest_DTO
    {
        [Required]
        [MaxLength(3)]
        public string Code { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0,55)]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
