using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DTOs.BookingDTO;
using Service.BaseService;
using Service.Interfaces;

namespace Service.Services
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // Lấy lịch sử booking của user hiện tại qua route gateway đã giấu userId
        public async Task<List<BookingReadDto>> GetBookingHistoryAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gọi API qua gateway, URL như định nghĩa ocelot
            var response = await _httpClient.GetAsync("/bookings/history");

            if (!response.IsSuccessStatusCode)
            {
                // Có thể log hoặc ném exception tùy nghiệp vụ
                return new List<BookingReadDto>();
            }

            var bookings = await response.Content.ReadFromJsonAsync<List<BookingReadDto>>();
            return bookings ?? new List<BookingReadDto>();
        }

        public async Task<BookingReadDto?> CreateBookingAsync(BookingCreateDto bookingCreateDto, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gọi đúng route Ocelot mapping tới backend CreateBooking
            var response = await _httpClient.PostAsJsonAsync("/Bookings/add", bookingCreateDto);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                // Có thể log hoặc throw exception tùy ý
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"API CreateBooking failed: {errorMessage}");
            }

            // Deserialize kết quả từ backend (có cả BookingDetails)
            var createdBooking = await response.Content.ReadFromJsonAsync<BookingReadDto>();

            return createdBooking;
        }


    }
}
