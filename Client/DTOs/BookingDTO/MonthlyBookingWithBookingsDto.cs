using DTOs.BookingDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml; // Thêm using này

namespace DTOs.BookingDTO
{
    public class MonthlyBookingWithBookingsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StadiumId { get; set; }
        public int? DiscountId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public string Note { get; set; }
        public int TotalHour { get; set; }

        // Áp dụng Converter vào đây
        [JsonConverter(typeof(IsoDurationTimeSpanConverter))]
        public TimeSpan StartTime { get; set; }

        // Và ở đây
        [JsonConverter(typeof(IsoDurationTimeSpanConverter))]
        public TimeSpan EndTime { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public List<BookingReadDto> Bookings { get; set; } = new List<BookingReadDto>();
    }

    // =======================================================
    // LỚP HELPER ĐƯỢC ĐỊNH NGHĨA NGAY TẠI ĐÂY
    // =======================================================
    /// <summary>
    /// Converts an ISO 8601 duration string (e.g., "PT8H") to a TimeSpan.
    /// </summary>
    public class IsoDurationTimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return existingValue;
            }

            if (reader.TokenType == JsonToken.String)
            {
                string? value = reader.Value as string;
                if (string.IsNullOrEmpty(value))
                {
                    return existingValue;
                }
                try
                {
                    // XmlConvert can parse ISO 8601 duration format perfectly.
                    return XmlConvert.ToTimeSpan(value);
                }
                catch (Exception ex)
                {
                    throw new JsonSerializationException($"Error converting ISO 8601 duration '{value}' to TimeSpan.", ex);
                }
            }

            throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing duration.");
        }

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            // Convert TimeSpan back to ISO 8601 duration string format when sending data back.
            writer.WriteValue(XmlConvert.ToString(value));
        }
    }
}