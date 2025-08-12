namespace FindTeamAPI.Models
{
    public class TeamPost
    {
        public int Id { get; set; } // Unique identifier for the team post
        public string Name { get; set; } = string.Empty; // Name of the team
        public string Location { get; set; } = string.Empty; // Location of the team
        public string Sport { get; set; } = string.Empty; // Sport type of the team
        public int MaxPlayers { get; set; } // Maximum number of players allowed in the team
        public int NeededPlayers { get; set; } // Number of players still needed to complete the team
        public string Description { get; set; } = string.Empty; // Description of the team
        public DateTime CreatedAt { get; set; } // Timestamp when the post was created
        public DateTime UpdatedAt { get; set; } // Timestamp when the post was last updated
        public int CreatedBy { get; set; } // User ID of the creator
        public int BookingId { get; set; } // Foreign key to the Booking entity
    }
}
