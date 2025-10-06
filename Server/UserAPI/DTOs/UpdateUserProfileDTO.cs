using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using UserAPI.Validator;

namespace UserAPI.DTOs
{
    public class UpdateUserProfileDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = null!;

        [AllowNull]
        [MaxLength(200)]
        public string? Address { get; set; }

        [AllowNull]
        [MaxLength(15)]
        [AllowEmptyPhone]
        [RegularExpression(@"^$|^[+]?[(]?[0-9]{3}[)]?[-. ]?[0-9]{3}[-. ]?[0-9]{4,6}$", ErrorMessage = "Định dạng số điện thoại không hợp lệ.")]
        public string? PhoneNumber { get; set; }

        [AllowNull]
        public string? Gender { get; set; }

        [AllowNull]
        public string? DateOfBirth { get; set; }
    }
}
