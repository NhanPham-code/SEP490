namespace DTOs.BookingDTO
{
    public class BookingReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? DiscountId { get; set; }
        public List<BookingDetailReadDto> BookingDetails { get; set; } = new List<BookingDetailReadDto>();
    }
}
