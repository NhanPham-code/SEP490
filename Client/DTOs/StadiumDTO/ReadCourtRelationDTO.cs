using DTOs.StadiumDTO;
using System.ComponentModel.DataAnnotations;

namespace StadiumAPI.DTOs
{
    public class ReadCourtRelationDTO
    {
        public int Id { get; set; }

        [Required]
        public int ParentCourtId { get; set; } // ví dụ: sân 7

        [Required]
        public int ChildCourtId { get; set; } // ví dụ: sân 5A
        // Navigation
        public ReadCourtDTO ParentCourt { get; set; }
        public ReadCourtDTO ChildCourt { get; set; }
    }
}
