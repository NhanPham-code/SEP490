namespace DTOs.UserDTO
{
    public class ReadUserDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }

        public string? FaceImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
