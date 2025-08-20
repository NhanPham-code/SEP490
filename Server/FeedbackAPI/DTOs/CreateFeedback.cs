using System.ComponentModel.DataAnnotations;

namespace FeedbackAPI.DTOs
{
    public class CreateFeedback
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int StadiumId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }



        [MaxLength(1000)]
        public string? Comment { get; set; }
    }
}
