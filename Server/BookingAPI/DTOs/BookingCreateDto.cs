using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookingAPI.DTOs
{
    public class BookingCreateDto
    {
        public int UserId { get; set; }
        public string Status { get; set; } = "pending";
        public DateTime Date { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string? Note { get; set; }
        public string? PaymentMethod { get; set; }
        public int? DiscountId { get; set; }
        public int StadiumId { get; set; }
        public List<BookingDetailCreateDto> BookingDetails { get; set; } = new List<BookingDetailCreateDto>();
    }
}
