using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.OData
{
    public class OdataHaveCountResponse <T>
    {
        // 2. Thay đổi Attribute từ [JsonPropertyName] thành [JsonProperty]
        [JsonProperty("@odata.context")]
        public string? ODataContext { get; set; }

        [JsonProperty("@odata.count")]
        public int? Count { get; set; }

        [JsonProperty("value")]
        public List<T> Value { get; set; } = new List<T>();
    }
}
