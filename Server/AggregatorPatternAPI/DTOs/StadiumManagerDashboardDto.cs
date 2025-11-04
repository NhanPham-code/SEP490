namespace AggregatorPatternAPI.DTOs
{
    public class StadiumManagerDashboardDto
    {
        public int ManagedStadiumsCount { get; set; }
        public int SuccessfulBookings { get; set; }
        public int FailedBookings { get; set; }
        public int BookingsToday { get; set; }
        public decimal RevenueToday { get; set; }

        public List<WeeklyRevenuePoint> WeeklyRevenueChartData { get; set; } = new();
        public List<BookingStatusCount> BookingStatusChartData { get; set; } = new();

        // THAY ĐỔI Ở ĐÂY: Sử dụng DTO đã được làm giàu
        public List<EnrichedFeedbackDto> LatestFeedbacks { get; set; } = new();
    }
}
