using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.DTOs
{
    public class ReadStadiumImageDTO
    {
        public int Id { get; set; }

        public int StadiumId { get; set; }

        public string ImageUrl { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
