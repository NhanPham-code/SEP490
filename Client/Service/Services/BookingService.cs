using DTOs.BookingDTO;
using Newtonsoft.Json;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

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
            // Sử dụng HttpRequestMessage để set token thủ công
            var request = new HttpRequestMessage(HttpMethod.Get, "/bookings/history");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<BookingReadDto>();
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            // Deserialize theo kiểu DTO bao ngoài chứa 'value'
            var result = System.Text.Json.JsonSerializer.Deserialize<BookingHistoryResponseDto>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result?.Value ?? new List<BookingReadDto>();
        }

        // Lấy chi tiết booking theo Id
        public async Task<BookingReadDto?> GetBookingDetailAsync(string accessToken, int bookingId)
        {
            AddBearerAccessToken(accessToken);

            var response = await _httpClient.GetAsync($"/bookings/{bookingId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<BookingReadDto>();
        }

        // Tạo booking mới
        public async Task<BookingReadDto?> CreateBookingAsync(BookingCreateDto bookingCreateDto, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            var response = await _httpClient.PostAsJsonAsync("/Bookings/add", bookingCreateDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"API CreateBooking failed: {errorMessage}");
            }

            return await response.Content.ReadFromJsonAsync<BookingReadDto>();
        }

        public async Task<List<BookingReadDto>> GetBookedCourtsAsync(int stadiumId, DateTime startTime, DateTime endTime)
        {
            //AddBearerAccessToken(accessToken);

            //yyyy → năm
            //MM → tháng
            //dd → ngày
            //T → ký tự cố định, ngăn cách ngày và giờ theo chuẩn ISO
            //HH:mm: ss → giờ: phút: giây
            //zzz → múi giờ hiện tại(VD: +07:00 cho Việt Nam)
            string startIso = Uri.EscapeDataString(startTime.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            string endIso = Uri.EscapeDataString(endTime.ToString("yyyy-MM-ddTHH:mm:sszzz"));


            string query = $"/bookings/booked?$filter=StadiumId eq {stadiumId} " +
               $"and BookingDetails/any(d: d/StartTime lt {endIso} and d/EndTime gt {startIso})" +
               "&$expand=BookingDetails";

            var response = await _httpClient.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                return new List<BookingReadDto>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<BookingHistoryResponseDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result?.Value ?? new List<BookingReadDto>();
        }

        public async Task<List<BookingReadDto>> GetBookedCourtsAsync(int stadiumId, DateTime date)
        {
            // Tạo khoảng thời gian từ đầu ngày đến cuối ngày
            var startTime = new DateTimeOffset(date.Date, TimeSpan.FromHours(7)); // +07:00
            var endTime = startTime.AddDays(1);

            // Encode đúng định dạng ISO + timezone
            string startIso = Uri.EscapeDataString(startTime.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            string endIso = Uri.EscapeDataString(endTime.ToString("yyyy-MM-ddTHH:mm:sszzz"));

            // Tạo query đúng định dạng OData
            string query = $"/bookings/booked?$filter=StadiumId eq {stadiumId} " +
                           $"and Date ge {startIso} and Date lt {endIso}" +
                           "&$expand=BookingDetails";

            var response = await _httpClient.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                return new List<BookingReadDto>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<BookingHistoryResponseDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result?.Value ?? new List<BookingReadDto>();
        }

        public async Task<List<BookingReadDto>> FilterByDateAndHour(int year, int month, List<int> days, int startTime, int endTime)
        {
            // Convert int thành "HH:mm"
            string startTimeStr = $"{startTime:D2}:00"; // 13 -> "13:00"
            string endTimeStr = $"{endTime:D2}:00";   // 17 -> "17:00"

            var query = new List<string>
            {
                $"year={year}",
                $"month={month}",
                $"startTime={Uri.EscapeDataString(startTimeStr)}",
                $"endTime={Uri.EscapeDataString(endTimeStr)}"
            };

            foreach (var d in days)
                query.Add($"days={d}");

            var queryString = string.Join("&", query);
            var url = $"https://localhost:7136/booking/filterbydateandhour?{queryString}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                // Fix: Deserialize to the correct type instead of object
                return JsonConvert.DeserializeObject<List<BookingReadDto>>(data);
            }
        }

        public async Task<List<BookingReadDto>> FilterByCourtAndHour(List<int> courtIds, int year, int month, int startTime, int endTime)
        {
            // Chuyển đổi giờ (int) sang định dạng chuỗi "HH:mm"
            string startTimeStr = $"{startTime:D2}:00"; // ví dụ: 13 -> "13:00"
            string endTimeStr = $"{endTime:D2}:00";   // ví dụ: 15 -> "15:00"

            // Xây dựng các tham số truy vấn
            var queryParams = new List<string>
            {
                $"year={year}",
                $"month={month}",
                $"startTime={Uri.EscapeDataString(startTimeStr)}",
                $"endTime={Uri.EscapeDataString(endTimeStr)}"
            };

            // Thêm từng courtId vào danh sách tham số
            foreach (var id in courtIds)
            {
                queryParams.Add($"courtIds={id}");
            }

            var queryString = string.Join("&", queryParams);

            // Sử dụng _httpClient đã được inject thay vì tạo mới
            // Endpoint này sẽ được Ocelot điều hướng đến 'https://localhost:7136/booking/filterbycourtandhour'
            var url = $"/booking/filterbycourtandhour?{queryString}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            // Deserialize dữ liệu JSON trả về
            return JsonConvert.DeserializeObject<List<BookingReadDto>>(data);
        }
    }
}