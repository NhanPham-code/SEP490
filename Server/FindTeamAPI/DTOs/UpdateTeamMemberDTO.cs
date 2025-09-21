using System.ComponentModel.DataAnnotations.Schema;

namespace FindTeamAPI.DTOs
{
    public class UpdateTeamMemberDTO
    {
        public int Id { get; set; } // Unique identifier for the team member

        public string role { get; set; }
    }
}
