using DTOs.BookingDTO;
using DTOs.StadiumDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FindTeamDTO
{
    public class BookingAndStadiumViewModel
    {
        public List<BookingReadDto> Bookings { get; set; }
        public Dictionary<int, ReadStadiumDTO> Stadiums { get; set; } = new Dictionary<int, ReadStadiumDTO>();
        public Dictionary<int, TimeSpan> Times { get; set; } = new Dictionary<int, TimeSpan>();

    }
}
