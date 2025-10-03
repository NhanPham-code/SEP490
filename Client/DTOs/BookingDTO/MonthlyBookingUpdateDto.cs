using System.ComponentModel.DataAnnotations;

namespace DTOs.BookingDTO
{
    public class MonthlyBookingUpdateDto
    {
        public decimal? OriginalPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? PaymentMethod { get; set; }

        public string? Note { get; set; }

        [StringLength(20)]
        public string? Status { get; set; }
        public List<int>? ChildBookingIdsToCancel { get; set; }
    }
}
