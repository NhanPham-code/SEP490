using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindTeamAPI.DTOs
{
    public class CreateTeamMemberDTO
    {
        [Required]
        public int TeamPostId { get; set; } // Foreign key to the TeamPost entity
        [Required]
        public int UserId { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.Now; // Timestamp when the member joined the team
        public string role { get; set; }
    }
}
