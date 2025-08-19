using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.Models
{
    public class CourtRelation
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("ParentCourt")]
        public int ParentCourtId { get; set; } // ví dụ: sân 7

        [Required, ForeignKey("ChildCourt")]
        public int ChildCourtId { get; set; } // ví dụ: sân 5A
        // Navigation
        public Courts ParentCourt { get; set; }
        public Courts ChildCourt { get; set; }
    }
}
