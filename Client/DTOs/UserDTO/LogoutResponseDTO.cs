namespace DTOs.UserDTO
{
    public class LogoutResponseDTO
    {
        public bool IsValid { get; set; } = false;
        public string Message { get; set; } = null!;
    }
}
