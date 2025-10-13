using BookingAPI.DTOs;
using StadiumAPI.DTOs;

namespace AggregatorPatternAPI.DTOs
{
    public class StadiumBookingOverviewDto
    {
        public int StadiumId { get; set; }
        public string StadiumName { get; set; }
        public List<ReadCourtDTO> Courts { get; set; }
        public int CompletedBookingsCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalOriginRevenue { get; set; }
        public List<EnrichedBookingDto> Bookings { get; set; } = new List<EnrichedBookingDto>();
        
    }
}