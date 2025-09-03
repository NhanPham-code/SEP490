namespace StadiumAPI.DTOs
{
    public class ReadStadiumVideoDTO
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public IFormFile VideoUrl { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}