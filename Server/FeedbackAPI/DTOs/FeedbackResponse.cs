namespace FeedbackAPI.DTOs
{
    public class FeedbackResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StadiumId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}