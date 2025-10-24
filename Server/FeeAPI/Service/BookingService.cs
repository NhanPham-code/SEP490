using FeeAPI.DTOs;
using FeeAPI.Service.Interface;
using Newtonsoft.Json;
using System.Text;

namespace FeeAPI.Service
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        // Định nghĩa URL của BookingAPI và endpoint cụ thể
        private const string BookingApiBaseUrl = "https://localhost:7015";
        private const string RevenueEndpoint = "/api/booking/revenue-by-stadiums";

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Gọi đến BookingAPI để lấy tổng doanh thu của một danh sách sân vận động trong một tháng cụ thể.
        /// </summary>
        /// <param name="revenueRequestDto">Đối tượng chứa danh sách StadiumIds, Year, và Month.</param>
        /// <returns>Một danh sách các đối tượng StadiumRevenueDto.</returns>
        public async Task<IEnumerable<StadiumRevenueDto>> GetStadiumRevenuesAsync(RevenueRequestDto revenueRequestDto)
        {
            if (revenueRequestDto == null || !revenueRequestDto.StadiumIds.Any())
            {
                // Nếu không có sân nào được yêu cầu, trả về một danh sách rỗng.
                return Enumerable.Empty<StadiumRevenueDto>();
            }

            // Tạo URL đầy đủ cho request
            string requestUrl = $"{BookingApiBaseUrl}{RevenueEndpoint}";

            try
            {
                // 1. Serialize request body thành JSON
                string jsonRequestBody = JsonConvert.SerializeObject(revenueRequestDto);
                var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

                // 2. Gửi POST request đến BookingAPI
                HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content);

                // 3. Đảm bảo request thành công (ném ra exception nếu có lỗi HTTP 4xx hoặc 5xx)
                response.EnsureSuccessStatusCode();

                // 4. Đọc nội dung response
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // 5. Deserialize JSON response thành danh sách DTO
                var stadiumRevenues = JsonConvert.DeserializeObject<IEnumerable<StadiumRevenueDto>>(jsonResponse);

                return stadiumRevenues ?? Enumerable.Empty<StadiumRevenueDto>();
            }
            catch (HttpRequestException ex)
            {
                // Bắt lỗi liên quan đến mạng hoặc HTTP status code không thành công
                // Ghi log lỗi ở đây nếu cần (ví dụ: logger.LogError(ex, ...))
                throw new Exception($"Lỗi khi gọi đến BookingAPI tại {requestUrl}: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                // Bắt lỗi khi parse JSON từ response (có thể do API trả về sai định dạng)
                throw new Exception($"Lỗi khi phân tích dữ liệu JSON từ BookingAPI: {ex.Message}", ex);
            }
        }
    }
}
