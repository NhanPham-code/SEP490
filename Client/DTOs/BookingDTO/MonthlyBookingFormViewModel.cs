using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.BookingDTO
{
    public class MonthlyBookingFormViewModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string SelectedDays { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string SelectedCourtIds { get; set; }
        public decimal TotalPrice { get; set; }
        public int StadiumId { get; set; }
    }
}
