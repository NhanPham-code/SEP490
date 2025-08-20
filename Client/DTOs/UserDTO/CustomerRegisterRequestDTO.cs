using DTOs.Validator;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DTOs.UserDTO
{
    public class CustomerRegisterRequestDTO
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public string Role { get; set; } = "None";

        public string? Address { get; set; }

        [Required, MaxLength(12), MinLength(9)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [GenderValidator]
        public string? Gender { get; set; }

        [DateOfBirth(18)] // bắt buộc >= 18 tuổi
        public string? DateOfBirth { get; set; }

        public IFormFile? Avatar { get; set; }

        public IFormFile? FaceVideo { get; set; }
    }
}
