using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.BookingDTO
{
    public class PendingPaymentSessionDto
    {
        public int BookingId { get; set; }
        public string Type { get; set; } // "Single" hoặc "Monthly"
        public string PaymentUrl { get; set; }
        public DateTime ExpireTime { get; set; } // Thời gian hết hạn (5 phút)
    }
}
