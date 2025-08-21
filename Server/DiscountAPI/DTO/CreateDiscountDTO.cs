using System.ComponentModel.DataAnnotations;

namespace DiscountAPI.DTO
{
    // CreateDiscountDTO
    public class CreateDiscountDTO
    {
        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        [Range(0, 100)]
        public double PercentValue { get; set; }

        public decimal MaxDiscountAmount { get; set; }
        public decimal MinOrderAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string CodeType { get; set; } = null!; // System / Stadium / Unique

        [Required]
        public string UserId { get; set; } = null!;

        // Nếu null hoặc rỗng => áp dụng toàn hệ thống
        public List<int>? StadiumIds { get; set; } = new();
    }
}
