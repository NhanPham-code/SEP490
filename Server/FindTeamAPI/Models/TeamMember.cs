using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindTeamAPI.Models
{
    [Index(nameof(TeamPostId))]
    [Index(nameof(UserId))]
    [Index(nameof(TeamPostId), nameof(UserId), IsUnique = true)] // 1 user chỉ được join 1 lần
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
