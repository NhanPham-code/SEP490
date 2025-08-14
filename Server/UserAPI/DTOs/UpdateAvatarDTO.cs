using System.ComponentModel.DataAnnotations;

namespace UserAPI.DTOs
{
    public class UpdateAvatarDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public IFormFile Avatar { get; set; } = null!;
    }
}
