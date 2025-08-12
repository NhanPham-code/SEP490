using System.ComponentModel.DataAnnotations.Schema;

namespace FindTeamAPI.Models
{
    public class TeamMember
    {
        public int Id { get; set; } // Unique identifier for the team member
        [ForeignKey("TeamPost")]
        public int TeamPostId { get; set; } // Foreign key to the TeamPost entity
        public string UserId { get; set; } = string.Empty; // User ID of the team member
        public DateTime JoinedAt { get; set; } // Timestamp when the member joined the team
        public bool IsCaptain { get; set; } // Indicates if the member is the captain of the team
        // Navigation property to the TeamPost entity
     
    }
}
