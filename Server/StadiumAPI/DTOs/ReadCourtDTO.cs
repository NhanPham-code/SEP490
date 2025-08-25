using StadiumAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.DTOs
{
    public class ReadCourtDTO
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

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Stadiums Stadium { get; set; }
        public virtual ICollection<CourtRelations> ParentRelations { get; set; } // Sân này là con của
        public virtual ICollection<CourtRelations> ChildRelations { get; set; }


    }
}
