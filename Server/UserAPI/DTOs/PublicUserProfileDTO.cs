namespace UserAPI.DTOs
{
    public class PublicUserProfileDTO
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? AvatarUrl { get; set; }
    }
}
