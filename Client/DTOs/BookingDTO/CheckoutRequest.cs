using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.BookingDTO
{
    public class CheckoutRequest
    {
        public string Date { get; set; }
        public decimal TotalPrice { get; set; }
        public string StadiumId { get; set; }
        public string Courts { get; set; }
    }
}
