using StadiumAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace StadiumAPI.DTOs
{
    public class UpdateCourtRelationDTO
    {
        public int Id { get; set; }

        [Required]
        public int ParentCourtId { get; set; } // ví dụ: sân 7

        [Required]
        public int ChildCourtId { get; set; } // ví dụ: sân 5A
        // Navigation
        public Courts ParentCourt { get; set; }
        public Courts ChildCourt { get; set; }
    }
}
