namespace FeeAPI.DTOs
{
    public class UploadBillImageDTO
    {
        public int FeeId { get; set; }
        public string? StadiumName { get; set; }
        public IFormFile? BillImage { get; set; }
    }
}
