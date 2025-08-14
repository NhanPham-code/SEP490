namespace DTOs.BookingDTO
{
    public class BookingDetailUpdateDto
    {
        public int Id { get; set; }
        public int CourtId { get; set; }

        // Navigation properties can be added if needed
        // public BookingReadDto Booking { get; set; }
        // public CourtReadDto Court { get; set; }
    }
}
