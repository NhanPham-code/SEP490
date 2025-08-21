using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.Models
{
    public class CourtRelations
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("ParentCourt")]
        public int ParentCourtId { get; set; } // Foreign key to Courts
        [Required, ForeignKey("ChildCourt")]
        public int ChildCourtId { get; set; } // Foreign key to Courts

        // Navigation properties
        public Courts ParentCourt { get; set; }
        public Courts ChildCourt { get; set; }
    }
}
