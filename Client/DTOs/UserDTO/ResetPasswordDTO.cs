using System.ComponentModel.DataAnnotations;

namespace DTOs.UserDTO
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; } = null!;
    }
}
