using System.Text.Json.Serialization;

namespace UserAPI.DTOs
{
    public class AiFaceRegisterResponseModel
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("embeddings")]
        public List<List<float>>? Embeddings { get; set; }
    }
}
