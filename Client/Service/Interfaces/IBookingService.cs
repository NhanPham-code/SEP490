using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.BookingDTO;

namespace Service.Interfaces
{
    public interface IBookingService
    {
        // Lấy lịch sử booking của user hiện tại, cần token để xác thực
        Task<List<BookingReadDto>> GetBookingHistoryAsync(string accessToken);
    }
}
