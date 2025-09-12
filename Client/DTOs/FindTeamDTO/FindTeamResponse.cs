using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FindTeamDTO
{
    public class FindTeamResponse <T>
    {
        [JsonProperty("@odata.context")]
        public string? ODataContext { get; set; }

        [JsonProperty("value")]
        public List<T> Value { get; set; } = new List<T>();

    }
}
