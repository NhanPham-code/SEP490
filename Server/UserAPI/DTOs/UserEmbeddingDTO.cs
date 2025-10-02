namespace UserAPI.DTOs
{
    public class UserEmbeddingDTO
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? FaceEmbeddingsJson { get; set; } = null!;
    }
}
