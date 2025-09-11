using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.BookingDTO
{
    public class CourtBookingDetail
    {
        public int CourtId { get; set; }
        public string Time { get; set; } // Định dạng: "HH:mm-HH:mm"
    }
}
