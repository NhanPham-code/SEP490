using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs.StadiumDTO
{
    public class UpdateStadiumImageDTO
    {
        public int Id { get; set; }

        public int StadiumId { get; set; }

        public IFormFile ImageUrl { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
