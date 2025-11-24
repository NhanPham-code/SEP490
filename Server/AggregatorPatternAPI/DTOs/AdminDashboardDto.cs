namespace AggregatorPatternAPI.DTOs
{
    public class AdminDashboardDto
    {
        // Dành cho các thẻ KPI
        public int TotalUsers { get; set; }
        public decimal NewUsersChangePercentage { get; set; }
        public decimal RevenueThisMonth { get; set; }
        public decimal RevenueChangePercentage { get; set; }
        public int TotalStadiums { get; set; }
        public int TotalFeedbacks { get; set; }

        // Dành cho các biểu đồ
        public List<MonthlyRevenueDto> RevenueLast6Months { get; set; } = new();
        public List<MonthlyCountDto> NewUsersLast6Months { get; set; } = new();
    }
}
