namespace FindTeamAPI.DTOs
{
    using global::DTOs.ConvertTime;
    using Newtonsoft.Json;

    public class ReadTeamPostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string SportType { get; set; } = string.Empty;
        public int MaxPlayers { get; set; }
        public int NeededPlayers { get; set; }
        public string Description { get; set; } = string.Empty;

        [JsonConverter(typeof(Iso8601TimeSpanConverter))]
        public TimeSpan TimePlay { get; set; }

        public DateTime PlayDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int StadiumId { get; set; }
        public int BookingId { get; set; }
    }

}
