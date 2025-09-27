using System.ComponentModel.DataAnnotations;

namespace StadiumEquipmentAPI.DTOs
{
    public class UpdateStadiumEquipment
    {
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
        public string? Status { get; set; }

        // File upload cho ảnh (optional khi update)
        public IFormFile? ImageFile { get; set; }

        // Có thể giữ lại ảnh cũ nếu không upload ảnh mới
        public bool KeepCurrentImage { get; set; } = false;
    }
}