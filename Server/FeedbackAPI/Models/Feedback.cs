using System.ComponentModel.DataAnnotations;

namespace FeedbackAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int StadiumId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        // Chỉ lưu path ảnh
        [MaxLength(500)]
        public string? ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
