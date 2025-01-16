using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model.DTO.RegisterDTO
{
    public class RegisterRequist_Dto
    {
        [Required]
        [DataType(DataType.EmailAddress)] 
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}
