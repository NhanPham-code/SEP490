using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.BookingDTO
{
    public class CourtBookingData
    {
        public int CourtId { get; set; }
        public string CourtName { get; set; }
        public List<string> Times { get; set; }
    }
}
