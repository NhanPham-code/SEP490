using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
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

        public async Task<List<BookingReadDto>> GetBookingHistoryAsync(string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7136/bookings/history");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            // Deserialize theo kiểu DTO bao ngoài chứa 'value'
            var result = JsonSerializer.Deserialize<BookingHistoryResponseDto>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result?.Value ?? new List<BookingReadDto>();
        }
    }
}
