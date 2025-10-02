using System.ComponentModel.DataAnnotations;
using UserAPI.Validator;

namespace UserAPI.DTOs
{
    public class CustomerRegisterRequestDTO
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public string? Address { get; set; }

        [Required, MaxLength(12), MinLength(9)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [GenderValidator]
        public string? Gender { get; set; }

        [DateOfBirth(15)] // bắt buộc >= 15 tuổi đối với khách hàng
        public string? DateOfBirth { get; set; }

        public IFormFile? Avatar { get; set; }

        // thêm 5 ảnh khuông mặt
        public List<IFormFile>? FaceImages { get; set; }
    }
}
