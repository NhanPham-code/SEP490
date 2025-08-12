using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.DTOs
{
    public class CreateStadiumImageDTO
    {

        public int StadiumId { get; set; }

        public IFormFile ImageUrl { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
