namespace BookingAPI.DTOs
{
    public class BookingDetailCreateDto
    {
        public int CourtId { get; set; }
        public DateTime StartTime { get; set; }  // đổi sang DateTime
        public DateTime EndTime { get; set; }    // đổi sang DateTime
    }
}
