using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DTOs.UserDTO
{
    public class UpdateAvatarDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public IFormFile Avatar { get; set; } = null!;
    }
}
