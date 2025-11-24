namespace AggregatorPatternAPI.DTOs
{
    // DTO này chứa các chỉ số KPI cho một nhóm sân vận động
    public class RichStadiumKpiDto
    {
        public int SuccessfulBookings { get; set; } // accepted & completed
        public int FailedBookings { get; set; } // cancelled & payfail
        public int BookingsToday { get; set; }
        public decimal RevenueToday { get; set; }

        // Dữ liệu bán-thô để Aggregator xử lý thành biểu đồ
        public List<WeeklyRevenuePoint> WeeklyRevenueData { get; set; } = new();
        public List<BookingStatusCount> BookingStatusData { get; set; } = new();
    }

    // Các DTO phụ trợ
    public class WeeklyRevenuePoint
    {
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class BookingStatusCount
    {
        public string Status { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
