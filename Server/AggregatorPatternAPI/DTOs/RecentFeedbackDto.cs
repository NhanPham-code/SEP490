namespace AggregatorPatternAPI.DTOs
{
    public class RecentFeedbackDto
    {
        public string UserName { get; set; } = string.Empty;
        public string? UserAvatarUrl { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
