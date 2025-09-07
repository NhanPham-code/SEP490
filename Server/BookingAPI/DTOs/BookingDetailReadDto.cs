namespace BookingAPI.DTOs
{
    public class BookingDetailReadDto
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int CourtId { get; set; }
        public DateTime StartTime { get; set; }  // đổi sang DateTime
        public DateTime EndTime { get; set; }    // đổi sang DateTime

        // Navigation properties can be added if needed
        // public BookingReadDto Booking { get; set; }
        // public CourtReadDto Court { get; set; }
    }
}
