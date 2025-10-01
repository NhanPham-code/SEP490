using System.Text.Json.Serialization;

namespace DTOs.BookingDTO
{
    public class RevenueStatisticViewModel
    {
        public decimal TotalRevenue { get; set; }
        public int TotalCompletedBookings { get; set; }
        public double CompletedBookingsPercentage { get; set; }
        public int PendingBookingsCount { get; set; }
        public int AcceptedBookingsCount { get; set; }
        public double WaitingBookingsPercentage { get; set; }
        public int CancelledBookingsCount { get; set; }
        public double CancelledBookingsPercentage { get; set; }
        public Dictionary<int, Dictionary<int, decimal>> MonthlyRevenueChartData { get; set; } = new Dictionary<int, Dictionary<int, decimal>>();
    }
}