namespace UserAPI.DTOs
{
    public class GoogleUserInfoDTO
    {
        public string GoogleId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public bool EmailVerified { get; set; }
    }
}
