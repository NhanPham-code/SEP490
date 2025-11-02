namespace AggregatorPatternAPI.DTOs
{
    public class EnrichedFeedbackDto : ReadFeedbackDTO
    {
        public UserProfileDto? User { get; set; }

        public string? StadiumName { get; set; }
    }
}
