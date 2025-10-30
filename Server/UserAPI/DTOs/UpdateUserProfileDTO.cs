using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using UserAPI.Validator;

namespace UserAPI.DTOs
{
    public class UpdateUserProfileDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống.")]
        [StringLength(100, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự.")]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = null!;

        [AllowNull]
        [MaxLength(200)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [RegularExpression(@"^(0[35789])\d{8}$", ErrorMessage = "Số điện thoại không đúng định dạng Việt Nam.")]
        public string? PhoneNumber { get; set; }

        [AllowNull]
        public string? Gender { get; set; }

        [AllowNull]
        public string? DateOfBirth { get; set; }
    }
}
