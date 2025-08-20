using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindTeamAPI.DTOs
{
    public class CreateTeamMemberDTO
    {
        [Required]
        public int TeamPostId { get; set; } // Foreign key to the TeamPost entity
        [Required]
        public string UserId { get; set; } = string.Empty; // User ID of the team member
        public DateTime JoinedAt { get; set; } // Timestamp when the member joined the team
        public bool IsCaptain { get; set; } // Indicates if the member is the captain of the team
    }
}
