using StadiumAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.DTOs
{
    public class UpdateCourtDTO
    {
        public int Id { get; set; }

        [Required]
        public int StadiumId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Loại sân: "5", "7", "11", "Futsal" ...
        /// </summary>
        [Required, MaxLength(50)]
        public string SportType { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal PricePerHour { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation

    }
}
