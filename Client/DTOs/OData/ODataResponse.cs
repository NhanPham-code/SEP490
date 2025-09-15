using Newtonsoft.Json; // 1. Thay đổi using
using System.Collections.Generic;

namespace DTOs.OData
{
    /// <summary>
    /// Represents a generic OData response structure for use with Newtonsoft.Json.
    /// The main data is in the 'value' property.
    /// </summary>
    /// <typeparam name="T">The type of the data objects in the response.</typeparam>
    public class ODataResponse<T>
    {
        // 2. Thay đổi Attribute từ [JsonPropertyName] thành [JsonProperty]
        [JsonProperty("@odata.context")]
        public string? ODataContext { get; set; }

        [JsonProperty("value")]
        public List<T> Value { get; set; } = new List<T>();
    }
}