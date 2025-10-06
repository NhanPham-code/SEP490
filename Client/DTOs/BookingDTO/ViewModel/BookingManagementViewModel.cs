using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.UserDTO;

namespace DTOs.BookingDTO.ViewModel
{
    // ViewModel mới cho DailyBooking, chứa cả thông tin User
    public class DailyBookingWithUserViewModel
    {
        public BookingReadDto Booking { get; set; } = new BookingReadDto();
        public PublicUserProfileDTO User { get; set; } = new PublicUserProfileDTO();
    }

    // ViewModel mới cho MonthlyBooking, chứa cả thông tin User và các booking con cũng có User
    public class MonthlyBookingWithDetailsViewModel
    {
        public MonthlyBookingReadDto MonthlyBooking { get; set; } = new MonthlyBookingReadDto();
        public List<BookingReadDto> Bookings { get; set; } = new List<BookingReadDto>();
        public PublicUserProfileDTO User { get; set; } = new PublicUserProfileDTO();
    }

    // ViewModel chính cho trang
    public class BookingManagementViewModel
    {
        public List<DailyBookingWithUserViewModel> DailyBookings { get; set; } = new List<DailyBookingWithUserViewModel>();
        public List<MonthlyBookingWithDetailsViewModel> MonthlyBookings { get; set; } = new List<MonthlyBookingWithDetailsViewModel>();
    }
    public class BookingDetailViewModel
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int CourtId { get; set; }
        public string CourtName { get; set; } // <-- DỮ LIỆU MỚI QUAN TRỌNG
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }


}