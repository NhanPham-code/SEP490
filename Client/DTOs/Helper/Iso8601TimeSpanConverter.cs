using System;
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
                throw new JsonException($"Unexpected token parsing TimeSpan. Token: {reader.TokenType}");

            string? value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value))
                return TimeSpan.Zero;

            try
            {
                // Ưu tiên parse theo ISO 8601 (PTxxHxxMxxS)
                return XmlConvert.ToTimeSpan(value);
            }
            catch (FormatException)
            {
                // Nếu không phải ISO 8601 thì fallback "HH:mm:ss"
                if (TimeSpan.TryParse(value, out var ts))
                    return ts;

                throw new JsonException($"Invalid TimeSpan format: {value}");
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            // Xuất ra theo ISO 8601 để khớp với backend
            writer.WriteStringValue(XmlConvert.ToString(value));
        }
    }
}
