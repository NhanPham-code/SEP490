using DTOs.ConvertTime;
using Newtonsoft.Json;

namespace DTOs.StadiumDTO
{
    public class ReadStadiumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameUnsigned { get; set; }
        public string Address { get; set; }
        public string AddressUnsigned { get; set; }
        public string Description { get; set; } = string.Empty;
        [JsonConverter(typeof(Iso8601TimeSpanConverter))]
        public TimeSpan OpenTime { get; set; }
        [JsonConverter(typeof(Iso8601TimeSpanConverter))]
        public TimeSpan CloseTime { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool IsApproved { get; set; }
        public int CreatedBy { get; set; } // User ID of the creator
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsLocked { get; set; }
        public ICollection<ReadCourtDTO> Courts { get; set; }
        public ICollection<ReadStadiumImageDTO> StadiumImages { get; set; }
    }
}