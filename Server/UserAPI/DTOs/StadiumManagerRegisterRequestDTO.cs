using System.ComponentModel.DataAnnotations;
using UserAPI.Validator;

namespace UserAPI.DTOs
{
    public class StadiumManagerRegisterRequestDTO
    {

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? PhoneNumber { get; set; }

        public IFormFile? Avatar { get; set; }

        public IFormFile? FrontCCCDImage { get; set; }

        public IFormFile? RearCCCDImage { get; set; }
    }
}
