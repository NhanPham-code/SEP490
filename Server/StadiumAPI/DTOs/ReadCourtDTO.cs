using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.DTOs
{
    public class ReadCourtDTO
    {
        public int Id { get; set; }

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

        public bool IsAvailable { get; set; } 

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
