using System.ComponentModel.DataAnnotations;

namespace StadiumEquipmentAPI.Models
{
    public class StadiumEquipments
    {
        public int Id { get; set; }

        [Required]
        public int StadiumId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity total must be non-negative")]
        public int QuantityTotal { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity available must be non-negative")]
        public int QuantityAvailable { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; } = "Active";

        // Chỉ lưu path ảnh (tương tự như Feedback)
        [MaxLength(500)]
        public string? ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}