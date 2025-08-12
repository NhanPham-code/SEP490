using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.Models
{
    public class Stadiums
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        [Required]
        public TimeSpan OpenTime { get; set; }

        [Required]
        public TimeSpan CloseTime { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal? Longitude { get; set; }

        public bool IsApproved { get; set; } = false;

        public int CreatedBy { get; set; }

        public int CreatedByUser { get; set; } // Navigation property

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; }
    }
}
