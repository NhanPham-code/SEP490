using System.ComponentModel.DataAnnotations;

namespace UserAPI.Model
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        public byte[] PasswordHash { get; set; } = null!;

        [Required]
        public byte[] PasswordSalt { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = "None"; // hoặc "StadiumManager", "Customer", "Admin"

        [MaxLength(200)]
        public string? Address { get; set; }

        [Phone]
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        public string? AvatarUrl { get; set; }

        public string? FaceImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<RefreshToken>? RefreshTokens { get; set; }
    }
}
