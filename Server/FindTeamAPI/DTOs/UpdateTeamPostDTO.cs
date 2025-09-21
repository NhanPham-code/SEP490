using System.ComponentModel.DataAnnotations;

namespace FindTeamAPI.DTOs
{
    public class UpdateTeamPostDTO
    {
        public int Id { get; set; } // Unique identifier for the team post
        [Required(ErrorMessage = "Name is required.")]
        public string Title { get; set; } = string.Empty; // Name of the team
        public int JoinedPlayers { get; set; }
        public decimal PricePerPerson { get; set; }

        public string Description { get; set; } = string.Empty; // Description of the team

        public DateTime UpdatedAt { get; set; } // Timestamp when the post was last updated

    }
}
