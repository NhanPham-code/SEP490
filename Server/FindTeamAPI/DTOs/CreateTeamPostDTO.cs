using System.ComponentModel.DataAnnotations;

namespace FindTeamAPI.DTOs
{
    public class CreateTeamPostDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Title { get; set; } = string.Empty; // Name of the team
        public string Location { get; set; } = string.Empty; // Location of the team
        public string SportType { get; set; } = string.Empty; // Sport type of the team
        public int JoinedPlayers { get; set; }
        [Required(ErrorMessage = "NeededPlayers is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "NeededPlayers must be at least 1.")]
        public int NeededPlayers { get; set; } // Number of players still needed to complete the team
        public decimal PricePerPerson { get; set; }
        public string? Description { get; set; } = string.Empty; // Description of the team
        public TimeSpan TimePlay { get; set; } // Time when the team plays
        public DateTime PlayDate { get; set; } // Date when the team plays
        public DateTime CreatedAt { get; set; } // Timestamp when the post was created
        public DateTime UpdatedAt { get; set; } // Timestamp when the post was last updated
        [Required(ErrorMessage = "CreatedBy is required.")]
        public int CreatedBy { get; set; } // User ID of the creator
        [Required(ErrorMessage = "BookingId is required.")]
        public int BookingId { get; set; } // Foreign key to the Booking entity
        public int StadiumId { get; set; }
    }
}
