using StadiumAPI.DTOs;
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

        public string NameUnsigned { get; set; }

        public string Address { get; set; }
        public string AddressUnsigned { get; set; }

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


        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool IsLocked { get; set; }

        public virtual ICollection<Courts> Courts { get; set; } // Sử dụng Courts thay vì ReadCourtDTO
        public virtual ICollection<StadiumImages> StadiumImages { get; set; }
        public virtual ICollection<StadiumVideos> StadiumVideos { get; set; }
    }
}