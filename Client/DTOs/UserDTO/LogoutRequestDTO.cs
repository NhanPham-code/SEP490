namespace DTOs.UserDTO
{
    public class LogoutRequestDTO
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
