using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
<<<<<<< Updated upstream
using System.Text.Json;
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            // Sử dụng HttpRequestMessage để set token thủ công
            var request = new HttpRequestMessage(HttpMethod.Get, "/bookings/history");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<BookingReadDto>();
            }
=======
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.GetAsync("/bookings/history");
            response.EnsureSuccessStatusCode();
            var bookings = await response.Content.ReadFromJsonAsync<List<BookingReadDto>>();
            return bookings ?? new List<BookingReadDto>();
        }
>>>>>>> Stashed changes

        // Phương thức mới để lấy chi tiết booking
        public async Task<BookingReadDto> GetBookingDetailAsync(string accessToken, int bookingId)
        {
            AddBearerAccessToken(accessToken);

            // Gọi API qua gateway, URL như đã định nghĩa trong Ocelot
            var response = await _httpClient.GetAsync($"/bookings/{bookingId}");                 

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var booking = await response.Content.ReadFromJsonAsync<BookingReadDto>();
            return booking;
        }

        // Tạo booking mới
        public async Task<BookingReadDto?> CreateBookingAsync(BookingCreateDto bookingCreateDto, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gọi đúng route Ocelot mapping tới backend CreateBooking
            var response = await _httpClient.PostAsJsonAsync("/Bookings/add", bookingCreateDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"API CreateBooking failed: {errorMessage}");
            }

            // Deserialize kết quả từ backend (có cả BookingDetails)
            var createdBooking = await response.Content.ReadFromJsonAsync<BookingReadDto>();

            return createdBooking;
        }
    }
}