using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookingAPI.DTOs
{
    public class BookingCreateDto
    {
        [Required]
        public int UserId { get; set; }

        public string Status { get; set; } = "pending";

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [JsonPropertyName("startTime")]
        public string StartTimeString { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("endTime")]
        public string EndTimeString { get; set; } = string.Empty;

        public decimal? TotalPrice { get; set; }
        public string? Note { get; set; }
        public int? DiscountId { get; set; }

        [Required]
        public List<BookingDetailCreateDto> BookingDetails { get; set; } = new List<BookingDetailCreateDto>();

        // Properties để convert string thành TimeSpan
        [JsonIgnore]
        public TimeSpan StartTime => TimeSpan.Parse(StartTimeString);

        [JsonIgnore]
        public TimeSpan EndTime => TimeSpan.Parse(EndTimeString);
    }
}
