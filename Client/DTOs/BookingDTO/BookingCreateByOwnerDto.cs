using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTOs.BookingDTO
{
    public class BookingCreateByOwnerDto
    {
        public int StadiumId { get; set; }
        public DateTime Date { get; set; }
        public long TotalPrice { get; set; }
        public long OriginalPrice { get; set; }
        public int UserId { get; set; } 
        public string Status { get; set; } = "accepted";
        public string? Note { get; set; }
        public List<BookingDetailCreateDto> BookingDetails { get; set; } = new List<BookingDetailCreateDto>();
    }
}
