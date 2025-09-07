using System.ComponentModel.DataAnnotations;

namespace BookingAPI.DTOs
{
    public class BookingUpdateDto
    {
        public int UserId { get; set; }
        public string Status { get; set; } = "pending";
        public DateTime Date { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string? Note { get; set; }
        public int? DiscountId { get; set; }
        public int StadiumId { get; set; }

        /*        public List<BookingDetailUpdateDto> BookingDetails { get; set; } = new List<BookingDetailUpdateDto>();*/
    }
}
