using System.ComponentModel.DataAnnotations;

namespace UserAPI.DTOs
{
    public class RegisterRequestDTO
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

        public IFormFile? Avatar { get; set; }

        public IFormFile? FaceImage { get; set; }
    }
}
