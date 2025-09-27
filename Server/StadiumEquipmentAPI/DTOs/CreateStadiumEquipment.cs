using System.ComponentModel.DataAnnotations;

namespace StadiumEquipmentAPI.DTOs
{
    public class CreateStadiumEquipment
    {
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

        // File upload cho ảnh
        public IFormFile? ImageFile { get; set; }
    }
}