using System.ComponentModel.DataAnnotations;

namespace BookingAPI.DTOs
{
    public class BookingUpdateDto
    {
        public int UserId { get; set; }
        public string Status { get; set; } = "pending";
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }  // đổi sang DateTime
        public DateTime EndTime { get; set; }    // đổi sang DateTime
        public decimal? TotalPrice { get; set; }
        public string? Note { get; set; }
        public int? DiscountId { get; set; }
        public int StadiumId { get; set; }

        /*        public List<BookingDetailUpdateDto> BookingDetails { get; set; } = new List<BookingDetailUpdateDto>();*/
    }
}
