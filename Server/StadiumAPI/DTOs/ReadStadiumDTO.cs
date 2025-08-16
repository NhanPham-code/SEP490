using StadiumAPI.Models;

namespace StadiumAPI.DTOs
{
    public class ReadStadiumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool IsApproved { get; set; } 
        public int CreatedBy { get; set; } // User ID of the creator
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public ICollection<ReadCourtDTO> Courts { get; set; }
        public ICollection<ReadStadiumImageDTO> StadiumImages { get; set; }

    }
}
