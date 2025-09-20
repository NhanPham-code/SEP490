using System.ComponentModel.DataAnnotations;

namespace UserAPI.DTOs
{
    public class AdminUserProfileDTO
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Role { get; set; } = "None";

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string? AvatarUrl { get; set; }

        public string? IdentityNumber { get; set; }

        public string? FrontCCCDUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? CreatedDate { get; set; }
    }
}
