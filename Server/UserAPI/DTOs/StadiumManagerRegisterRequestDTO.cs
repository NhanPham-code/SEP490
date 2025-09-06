using System.ComponentModel.DataAnnotations;
using UserAPI.Validator;

namespace UserAPI.DTOs
{
    public class StadiumManagerRegisterRequestDTO
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; } = "None";

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        [DateOfBirth(18)] // bắt buộc >= 18 tuổi
        public string? DateOfBirth { get; set; }

        public IFormFile? Avatar { get; set; }

        public IFormFile? FrontCCCDImage { get; set; }

        public IFormFile? RearCCCDImage { get; set; }
    }
}
