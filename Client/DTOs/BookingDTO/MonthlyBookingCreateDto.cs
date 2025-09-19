using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOs.BookingDTO
{
    public class MonthlyBookingCreateDto
    {
        [Required]
        public int StadiumId { get; set; }

        public int? DiscountId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal OriginalPrice { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public string StartTime { get; set; } // "HH:mm" e.g., "13:00"

        [Required]
        public string EndTime { get; set; } // "HH:mm" e.g., "15:00"

        [Required]
        [Range(1, 12)]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public List<int> Dates { get; set; } = new List<int>();

        [Required]
        public List<int> CourtIds { get; set; } = new List<int>();
    }
}