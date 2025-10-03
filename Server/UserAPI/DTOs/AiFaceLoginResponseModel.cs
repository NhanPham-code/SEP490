using System.Text.Json.Serialization;

namespace UserAPI.DTOs
{
    public class AiFaceLoginResponseModel
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("similarity")]
        public float Similarity { get; set; }
    }
}
