using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTOs.BookingDTO
{
    public class BookingCreateDto
    {
        public int UserId { get; set; }
        public string Status { get; set; } = "pending";
        public DateTime Date { get; set; }             // yyyy-MM-dd
        public DateTime StartTime { get; set; }        // yyyy-MM-ddTHH:mm:ss
        public DateTime EndTime { get; set; }          // yyyy-MM-ddTHH:mm:ss
        public decimal? TotalPrice { get; set; }
        public string? Note { get; set; }
        public int? DiscountId { get; set; }
        public int StadiumId { get; set; }
        public List<BookingDetailCreateDto> BookingDetails { get; set; } = new List<BookingDetailCreateDto>();
    }
}
