namespace BookingAPI.DTOs
{
    public class BookingReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }  // đổi sang DateTime
        public DateTime EndTime { get; set; }    // đổi sang DateTime
        public decimal? TotalPrice { get; set; }
        public string? Note { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? DiscountId { get; set; }
        public int StadiumId { get; set; }
        public List<BookingDetailReadDto> BookingDetails { get; set; } = new List<BookingDetailReadDto>();
    }
}
