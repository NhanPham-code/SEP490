namespace DTOs.UserDTO
{
    public class LoginResponseDTO
    {
        public bool IsValid { get; set; }

        public string? Message { get; set; }

        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime AccessTokenExpiresAt { get; set; }

        public string? FullName { get; set; }

        public string? AvatarUrl { get; set; }

        public string? FaceImageUrl { get; set; }
    }
}
