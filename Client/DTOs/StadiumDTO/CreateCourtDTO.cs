using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs.StadiumDTO
{
    public class CreateCourtDTO
    {

        [Required]
        public int StadiumId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string SportType { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PricePerHour { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
