using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.DTOs
{
    public class CreateCourtRelationDTO
    {

        [Required]
        public int ParentCourtId { get; set; } // ví dụ: sân 7

        [Required]
        public int ChildCourtId { get; set; } // ví dụ: sân 5A
        // Navigation
    }
}
