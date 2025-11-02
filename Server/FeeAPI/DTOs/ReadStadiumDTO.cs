
using System.ComponentModel.DataAnnotations;

namespace FeeAPI.DTOs
{
    public class ReadStadiumDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string NameUnsigned { get; set; }

        public bool IsApproved { get; set; } = false;

        public int CreatedBy { get; set; }

        public bool IsLocked { get; set; }
    }
}