using System.ComponentModel.DataAnnotations;

namespace DTOs.BookingDTO
{
    // DTO để chứa thông tin yêu cầu kiểm tra một slot sân
    public class BookingSlotRequest
    {
        [Required]
        public int CourtId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}