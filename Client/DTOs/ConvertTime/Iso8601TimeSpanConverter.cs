using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace DTOs.ConvertTime
{
    public class Iso8601TimeSpanConverter : Newtonsoft.Json.JsonConverter<TimeSpan>
    {
        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            writer.WriteValue(XmlConvert.ToString(value)); // xuất thành ISO8601 nếu cần
        }

        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var str = reader.Value?.ToString();
            if (string.IsNullOrEmpty(str))
                return TimeSpan.Zero;

            // "PT12H" => TimeSpan
            return System.Xml.XmlConvert.ToTimeSpan(str);
        }
    }
}
