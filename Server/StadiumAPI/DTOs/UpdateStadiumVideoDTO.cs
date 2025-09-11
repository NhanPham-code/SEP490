namespace StadiumAPI.DTOs
{
    public class UpdateStadiumVideoDTO
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public IFormFile VideoUrl { get; set; }
    }
}