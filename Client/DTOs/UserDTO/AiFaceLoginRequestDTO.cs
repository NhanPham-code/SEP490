using Microsoft.AspNetCore.Http;

namespace DTOs.UserDTO
{
    public class AiFaceLoginRequestDTO
    {
        public IFormFile? FaceImage { get; set; } = null!;
    }
}
