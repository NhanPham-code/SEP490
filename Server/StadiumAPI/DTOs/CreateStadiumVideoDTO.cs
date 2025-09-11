namespace StadiumAPI.DTOs
{
    public class CreateStadiumVideoDTO
    {
        public int StadiumId { get; set; }
        public IFormFile VideoUrl { get; set; }
    }
}