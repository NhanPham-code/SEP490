using Microsoft.OData;

namespace FindTeamAPI.Models
{
    public class TeamPost
    {
        public int Id { get; set; } // Unique identifier for the team post
        public string Title { get; set; } = string.Empty; // Name of the team
        public string Location { get; set; } = string.Empty; // Location of the team
        public string SportType { get; set; } = string.Empty; // Sport type of the team
        public int MaxPlayers { get; set; } // Maximum number of players allowed in the team
        public int NeededPlayers { get; set; } // Number of players still needed to complete the team
        public decimal PricePerPerson { get; set; }
        public string? Description { get; set; } = string.Empty; // Description of the teams
        public TimeSpan TimePlay { get; set; } // Time when the team plays
        public DateTime PlayDate { get; set; } // Date when the team plays
        public DateTime CreatedAt { get; set; } // Timestamp when the post was created
        public DateTime UpdatedAt { get; set; } // Timestamp when the post was last updated
        public int CreatedBy { get; set; } // User ID of the creator
        public int StadiumId { get; set; } // Foreign key to the Stadium entity
        public int BookingId { get; set; } // Foreign key to the Booking entity
        public virtual ICollection<TeamMember> TeamMembers { get; set; } 
    }
}
