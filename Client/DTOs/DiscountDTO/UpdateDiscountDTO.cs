using System.ComponentModel.DataAnnotations;

namespace DTOs.DiscountDTO
{
    public class UpdateDiscountDTO
    {
        [Required]
        public int Id { get; set; }

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
        public string CodeType { get; set; } = null!;

        public bool IsActive { get; set; }

        // Cập nhật danh sách stadium
        public List<int>? StadiumIds { get; set; } = new();
    }
}
