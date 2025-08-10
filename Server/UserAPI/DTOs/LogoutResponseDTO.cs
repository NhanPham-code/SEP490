namespace UserAPI.DTOs
{
    public class LogoutResponseDTO
    {
        public bool IsValid { get; set; } = false;
        public string Message { get; set; } = null!;
    }
}
