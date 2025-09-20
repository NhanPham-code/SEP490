using System.ComponentModel.DataAnnotations;

namespace BookingAPI.DTOs
{
    public class MonthlyBookingCreateDto
    {
        // [Required]
        // public int UserId { get; set; }

        [Required]
        public int StadiumId { get; set; }

        public int? DiscountId { get; set; }

        public decimal? OriginalPrice { get; set; }

        [Required]
        public decimal? TotalPrice { get; set; }

        public string? PaymentMethod { get; set; }

        public string? Note { get; set; }

        [Required]
        public string StartTime { get; set; } = string.Empty; // "HH:mm"

        [Required]
        public string EndTime { get; set; } = string.Empty; // "HH:mm"

        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least one date must be provided.")]
        public List<int> Dates { get; set; } = new List<int>();

        [Required]
        [MinLength(1, ErrorMessage = "At least one court must be provided.")]
        public List<int> CourtIds { get; set; } = new List<int>();
    }
}
