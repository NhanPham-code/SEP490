using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DTOs.UserDTO
{
    public class UpdateFaceImageDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public IFormFile FaceImage { get; set; } = null!;
    }
}
