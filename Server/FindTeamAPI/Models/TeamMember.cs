using System.ComponentModel.DataAnnotations.Schema;

namespace FindTeamAPI.Models
{
    public class TeamMember
    {
        public int Id { get; set; } // Unique identifier for the team member
        [ForeignKey("TeamPost")]
        public int TeamPostId { get; set; } // Foreign key to the TeamPost entity
        public int UserId { get; set; } 
        public DateTime JoinedAt { get; set; } // Timestamp when the member joined the team
        public string role { get; set; } 
        public virtual TeamPost TeamPost { get; set; }

    }
}
