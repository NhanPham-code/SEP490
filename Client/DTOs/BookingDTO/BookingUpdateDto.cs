namespace DTOs.BookingDTO
{
    public class BookingUpdateDto
    {
        public int UserId { get; set; }
        public string Status { get; set; } = "pending";
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Note { get; set; }
        public int? DiscountId { get; set; }

/*        public List<BookingDetailUpdateDto> BookingDetails { get; set; } = new List<BookingDetailUpdateDto>();*/
    }
}
