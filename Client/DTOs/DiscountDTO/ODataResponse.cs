using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTOs.DiscountDTO
{
    public class ODataResponse<T>
    {
        [JsonPropertyName("@odata.context")]
        public string Context { get; set; }

        [JsonPropertyName("value")]
        public List<T> Value { get; set; }

        [JsonPropertyName("@odata.count")]
        public int? Count { get; set; }
    }
}