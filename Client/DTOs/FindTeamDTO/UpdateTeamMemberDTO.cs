using System.ComponentModel.DataAnnotations.Schema;

namespace FindTeamAPI.DTOs
{
    public class UpdateTeamMemberDTO
    {
        public int Id { get; set; } // Unique identifier for the team member
        public int TeamPostId { get; set; } // Foreign key to the TeamPost entity
        public int UserId { get; set; }
        public DateTime JoinedAt { get; set; } // Timestamp when the member joined the team
        public string role { get; set; }
    }
}
