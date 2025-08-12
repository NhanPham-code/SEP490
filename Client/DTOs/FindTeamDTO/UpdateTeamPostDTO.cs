using System.ComponentModel.DataAnnotations;

namespace DTOs.FindTeamDTO
{
    public class UpdateTeamPostDTO
    {
        public int Id { get; set; } // Unique identifier for the team post
        [Required(ErrorMessage = "Name is required.")]
        public string Title { get; set; } = string.Empty; // Name of the team
        public string Location { get; set; } = string.Empty; // Location of the team
        public string Sport { get; set; } = string.Empty; // Sport type of the team
        [Required(ErrorMessage = "MaxPlayers is required.")]
        [Range(2, int.MaxValue, ErrorMessage = "MaxPlayers must be at least 1.")]
        public int MaxPlayers { get; set; } // Maximum number of players allowed in the team
        [Required(ErrorMessage = "NeededPlayers is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "NeededPlayers must be at least 1.")]
        public int NeededPlayers { get; set; } // Number of players still needed to complete the team
        public string Description { get; set; } = string.Empty; // Description of the team
        public DateTime CreatedAt { get; set; } // Timestamp when the post was created
        public DateTime UpdatedAt { get; set; } // Timestamp when the post was last updated
        [Required(ErrorMessage = "CreatedBy is required.")]
        public int CreatedBy { get; set; } // User ID of the creator
        [Required(ErrorMessage = "BookingId is required.")]
        public int BookingId { get; set; } // Foreign key to the Booking entity
    }
}
