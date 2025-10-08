using System.Collections.Generic;

namespace BookingAPI.DTOs
{
    public class RevenueStatisticDto
    {
        // Các chỉ số thống kê tổng quan (có thể lọc theo ngày, tháng, năm)
        public decimal TotalRevenue { get; set; }
        public decimal TotalOriginalRevenue { get; set; }
        public int TotalCompletedBookings { get; set; }
        public double CompletedBookingsPercentage { get; set; }
        public int PendingBookingsCount { get; set; }
        public int AcceptedBookingsCount { get; set; }
        public double WaitingBookingsPercentage { get; set; } // Tỉ lệ sân đang chờ (pending + accepted)
        public int CancelledBookingsCount { get; set; }
        public double CancelledBookingsPercentage { get; set; }
        public Dictionary<int, Dictionary<int, decimal>> MonthlyRevenueChartData { get; set; } = new Dictionary<int, Dictionary<int, decimal>>();
    }
}