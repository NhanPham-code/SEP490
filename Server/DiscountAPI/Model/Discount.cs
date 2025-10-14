using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        public string? Description { get; set; }

        [Range(0, 100)]
        public double PercentValue { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MaxDiscountAmount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MinOrderAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string CodeType { get; set; } 

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public string UserId { get; set; }

        public string? TargetUserId { get; set; }

        // Quan hệ 1-nhiều tới bảng trung gian
        public ICollection<DiscountStadium> DiscountStadiums { get; set; } = new List<DiscountStadium>();
    }
}
