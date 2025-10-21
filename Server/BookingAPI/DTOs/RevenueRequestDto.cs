using System.ComponentModel.DataAnnotations;

namespace BookingAPI.DTOs
{
    /// <summary>
    /// Dùng cho FeesAPI gửi qua BookingAPI để lấy doanh thu sân trong tháng
    /// </summary>
    public class RevenueRequestDto
    {
        [Required]
        [MinLength(1)]
        public required List<int> StadiumIds { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }
    }
}
