namespace StadiumAPI.DTOs
{
    public class ReadStadiumVideoDTO
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public string VideoUrl { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}