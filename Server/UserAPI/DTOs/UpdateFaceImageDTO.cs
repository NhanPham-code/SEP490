using System.ComponentModel.DataAnnotations;

namespace UserAPI.DTOs
{
    public class UpdateFaceImageDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public IFormFile FaceImage { get; set; } = null!;
    }
}
