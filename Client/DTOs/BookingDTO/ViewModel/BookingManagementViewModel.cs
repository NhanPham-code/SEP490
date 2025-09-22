using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.BookingDTO.ViewModel
{
    public class BookingManagementViewModel
    {
        public List<BookingReadDto> DailyBookings { get; set; } = new List<BookingReadDto>();
        public List<MonthlyBookingReadDto> MonthlyBookings { get; set; } = new List<MonthlyBookingReadDto>();
    }
}
