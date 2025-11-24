namespace BookingAPI.DTOs
{
    /// <summary>
    /// DTO chứa tất cả thống kê về booking và doanh thu cho Admin Dashboard.
    /// </summary>
    public class BookingStatisticsDto
    {
        public decimal RevenueThisMonth { get; set; }
        public decimal RevenueLastMonth { get; set; }
        public List<MonthlyRevenueDto> RevenueLast6Months { get; set; } = new();
    }

    /// <summary>
    /// DTO phụ trợ để biểu diễn dữ liệu doanh thu hàng tháng cho biểu đồ.
    /// </summary>
    public class MonthlyRevenueDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
