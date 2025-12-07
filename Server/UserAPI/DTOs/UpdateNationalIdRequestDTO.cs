using System.ComponentModel.DataAnnotations;

namespace UserAPI.DTOs
{
    public class UpdateNationalIdRequestDTO
    {
        [Required]
        public int UserId { get; set; } // ID của user cần update

        [Required]
        public IFormFile FrontCCCDImage { get; set; } = null!;
    }
}
