using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace StadiumManagerUI.Helpers
{
    public class Iso8601TimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Unexpected token type {reader.TokenType}. Expected a string.");
            }
            string value = reader.GetString();
            // XmlConvert có thể parse chính xác định dạng ISO 8601 duration
            return string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            // Ghi lại TimeSpan dưới dạng chuỗi ISO 8601 duration
            writer.WriteStringValue(XmlConvert.ToString(value));
        }
    }
}