using System.ComponentModel.DataAnnotations;

namespace UserAPI.DTOs
{
    public class GoogleApiLoginRequestDTO
    {
        [Required]
        public string IdToken { get; set; }
    }
}
