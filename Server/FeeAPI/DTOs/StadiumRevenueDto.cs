namespace FeeAPI.DTOs
{
    // <summary>
    // Dùng để trả về doanh thu sân từng tháng theo yêu cầu từ FeesAPI
    // </summary>
    public class StadiumRevenueDto
    {
        public int StadiumId { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
