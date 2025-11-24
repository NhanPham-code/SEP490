namespace AggregatorPatternAPI.DTOs
{
    // DTO này chứa tất cả thống kê liên quan đến người dùng cho Admin Dashboard
    public class UserStatisticsDto
    {
        public int TotalUsers { get; set; }
        public int NewUsersThisMonth { get; set; }
        public int NewUsersLastMonth { get; set; }
        public List<MonthlyCountDto> NewUsersLast6Months { get; set; } = new();
    }

    // DTO phụ trợ để biểu diễn dữ liệu biểu đồ hàng tháng
    public class MonthlyCountDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }
    }
}
