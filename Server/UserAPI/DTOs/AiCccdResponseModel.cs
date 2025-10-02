using System.Text.Json.Serialization;

namespace UserAPI.DTOs
{
    public class AiCccdResponseModel
    {
        [JsonPropertyName("name")]
        public List<string> Name { get; set; } = new List<string>();

        [JsonPropertyName("id")]
        public List<string> Id { get; set; } = new List<string>();

        [JsonPropertyName("dateOfBirth")]
        public List<string> DateOfBirth { get; set; } = new List<string>();

        [JsonPropertyName("originPlace")]
        public List<string> OriginPlace { get; set; } = new List<string>();

        // SỬA "current_place" thành "currentPlace"
        [JsonPropertyName("currentPlace")]
        public List<string> CurrentPlace { get; set; } = new List<string>();

        [JsonPropertyName("gender")]
        public List<string> Gender { get; set; } = new List<string>();
    }
}
