namespace BookingAPI.DTOs
{
    public class MonthlyBookingReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StadiumId { get; set; }
        public int? DiscountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal? OriginalPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string Status { get; set; } = "pending";
        public string? PaymentMethod { get; set; }
        public string? Note { get; set; }
        public int TotalHour { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public List<int> BookingIds { get; set; } = new List<int>();
    }
}
