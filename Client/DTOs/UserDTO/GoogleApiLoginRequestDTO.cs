using System.ComponentModel.DataAnnotations;

namespace DTOs.UserDTO
{
    public class GoogleApiLoginRequestDTO
    {
        [Required]
        public string IdToken { get; set; }
    }
}
