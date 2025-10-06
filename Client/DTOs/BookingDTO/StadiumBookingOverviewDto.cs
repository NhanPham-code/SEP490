using DTOs.StadiumDTO;

namespace DTOs.BookingDTO;

public class StadiumBookingOverviewDto
{
    public int StadiumId { get; set; }
    public string StadiumName { get; set; }
    public List<ReadCourtDTO> Courts { get; set; }
    public int CompletedBookingsCount { get; set; }
    public decimal TotalRevenue { get; set; }
    public List<BookingReadDto> Bookings { get; set; } = new List<BookingReadDto>();
}