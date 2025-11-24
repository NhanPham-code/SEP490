using DTOs.BookingDTO;
using DTOs.OData;
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
using DTOs.BookingDTO.RevenueViewModel;

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
        public async Task<(List<BookingReadDto> Data, int TotalCount)> GetBookingAsync(string accessToken, string queryString)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/bookings/history" + queryString);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return (new List<BookingReadDto>(), 0);
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            // Sử dụng DTO mới của bạn để deserialize
            var result = JsonConvert.DeserializeObject<OdataHaveCountResponse<BookingReadDto>>(jsonString);

            return (result?.Value ?? new List<BookingReadDto>(), result?.Count ?? 0);
        }

        public async Task<(List<MonthlyBookingReadDto> Data, int TotalCount)> GetMonthlyBookingAsync(string accessToken, string queryString)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/monthlyBooking" + queryString);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return (new List<MonthlyBookingReadDto>(), 0);
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            // Sử dụng DTO mới của bạn để deserialize
            var result = JsonConvert.DeserializeObject<OdataHaveCountResponse<MonthlyBookingReadDto>>(jsonString);

            return (result?.Value ?? new List<MonthlyBookingReadDto>(), result?.Count ?? 0);
        }

        public async Task<MonthlyBookingReadDto?> UpdateMonthlyBookingAsync(int id, MonthlyBookingUpdateDto bookingDto, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gọi đến endpoint Ocelot Gateway
            var response = await _httpClient.PutAsJsonAsync($"/booking/monthly/{id}", bookingDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error: {response.StatusCode} - {errorContent}");
                throw new Exception($"Cập nhật booking hàng tháng thất bại. Lỗi từ API: {errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<MonthlyBookingReadDto>();
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
        public async Task<BookingReadDto?> CreateBookingByOwnerAsync(BookingCreateDto bookingDto, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.PostAsJsonAsync("/Bookings/create-by-owner", bookingDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BookingReadDto>();
            }

            // Ghi log lỗi nếu cần
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Failed to create booking by owner. Status: {response.StatusCode}, Content: {errorContent}");

            return null;
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

            string statusFilter = "(Status eq 'waiting' or Status eq 'completed' or Status eq 'accepted')";


            string query = $"/bookings/booked?$filter=StadiumId eq {stadiumId} " +
                $"and BookingDetails/any(d: d/StartTime lt {endIso} and d/EndTime gt {startIso})" +
                $"and {statusFilter}" + // Thêm filter trạng thái vào đây
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

            string statusFilter = "(Status eq 'waiting' or Status eq 'completed' or Status eq 'accepted')";

            // Tạo query đúng định dạng OData
            string query = $"/bookings/booked?$filter=StadiumId eq {stadiumId} " +
                           $"and Date ge {startIso} and Date lt {endIso} " +
                           $"and {statusFilter}" +
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

        public async Task<List<BookingReadDto>> FilterByDateAndHour(int year, int month, List<int> days, int startHour,
            int endHour)
        {
            // --- Xây dựng các điều kiện OData cho từng ngày ---
            var anyDayConditions = new List<string>(); // Điều kiện cho BookingDetails/any(...)
            var expandDayConditions = new List<string>(); // Điều kiện cho $expand=BookingDetails($filter=...)

            foreach (var day in days)
            {
                // Tạo thời gian bắt đầu và kết thúc cho ngày hiện tại, giả định là UTC
                // để khớp với định dạng OData 'Z'.
                var start = new DateTime(year, month, day, startHour, 0, 0, DateTimeKind.Utc);
                var end = new DateTime(year, month, day, endHour, 0, 0, DateTimeKind.Utc);

                // Chuyển sang chuỗi ISO 8601 UTC mà OData yêu cầu (ví dụ: "2025-11-09T23:00:00Z")
                string startIso = start.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
                string endIso = end.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");

                // Điều kiện "overlap": một detail được tính là khớp nếu nó bắt đầu trước khi
                // khoảng thời gian của ta kết thúc VÀ kết thúc sau khi khoảng của ta bắt đầu.
                anyDayConditions.Add($"(d/StartTime lt {endIso} and d/EndTime gt {startIso})");
                expandDayConditions.Add($"(StartTime lt {endIso} and EndTime gt {startIso})");
            }

            // --- Ghép các điều kiện lại thành query OData ---

            // 1. Điều kiện $filter chính:
            // - Tìm các Booking có *bất kỳ* (any) BookingDetail nào khớp với *một trong các* ngày/giờ đã cho.
            // - Chỉ lấy các Booking có trạng thái nhất định.
            var anyClause = $"BookingDetails/any(d: {string.Join(" or ", anyDayConditions)})";
            var statusClause = "(Status eq 'waiting' or Status eq 'completed' or Status eq 'accepted')";

            // Kết hợp các điều kiện filter (không có StadiumId)
            var filterString = $"{anyClause} and {statusClause}";

            // 2. Điều kiện $expand:
            // - Yêu cầu server trả về các BookingDetails, nhưng chỉ những detail nào
            //   khớp với *một trong các* khoảng thời gian.
            var expandString = $"BookingDetails($filter={string.Join(" or ", expandDayConditions)})";

            // 3. Tạo URL cuối cùng
            // Sử dụng endpoint OData của bạn, ví dụ '/bookings/booked'
            var baseUrl = "https://localhost:7136/bookings/booked";
            var queryString =
                $"$filter={Uri.EscapeDataString(filterString)}&$expand={Uri.EscapeDataString(expandString)}";
            var url = $"{baseUrl}?{queryString}";

            // --- Gọi API và xử lý kết quả ---
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Ném lỗi nếu API trả về mã thất bại
                var data = await response.Content.ReadAsStringAsync();

                // Deserialize kết quả. Server đã lọc sẵn BookingDetails nên không cần xử lý thêm.
                return JsonConvert.DeserializeObject<List<BookingReadDto>>(data) ?? new List<BookingReadDto>();
            }
        }

        public async Task<List<BookingReadDto>> FilterByCourtAndHour(List<int> courtIds, int year, int month, int startTime, int endTime)
        {
            // Check if courtIds is null or empty.
            if (courtIds == null || !courtIds.Any())
            {
                // Return an empty list to indicate no results, without making an API call.
                return new List<BookingReadDto>();
            }

            // Convert hours (int) to "HH:mm" string format.
            string startTimeStr = $"{startTime:D2}:00"; // e.g., 13 -> "13:00"
            string endTimeStr = $"{endTime:D2}:00";   // e.g., 15 -> "15:00"

            // Build query parameters.
            var queryParams = new List<string>
            {
                $"year={year}",
                $"month={month}",
                $"startTime={Uri.EscapeDataString(startTimeStr)}",
                $"endTime={Uri.EscapeDataString(endTimeStr)}"
            };

            // Add each courtId to the parameter list.
            foreach (var id in courtIds)
            {
                queryParams.Add($"courtIds={id}");
            }

            var queryString = string.Join("&", queryParams);

            // Use the injected _httpClient instead of creating a new one.
            // This endpoint will be routed by Ocelot to 'https://localhost:7136/booking/filterbycourtandhour'.
            var url = $"/booking/filterbycourtandhour?{queryString}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON data returned.
            return JsonConvert.DeserializeObject<List<BookingReadDto>>(data);
        }

        public async Task<BookingReadDto?> CreateMonthlyBookingAsync(MonthlyBookingCreateDto bookingDto, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gọi đến endpoint của Ocelot API Gateway
            var response = await _httpClient.PostAsJsonAsync("/booking/monthly", bookingDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                // Log lỗi hoặc throw exception để Controller có thể bắt được
                Console.WriteLine($"API Error: {response.StatusCode} - {errorContent}");
                throw new Exception($"Tạo booking hàng tháng thất bại. Lỗi từ API: {errorContent}");
            }

            // Đọc và deserialize kết quả trả về nếu thành công
            return await response.Content.ReadFromJsonAsync<BookingReadDto>();
        }

        public async Task<BookingReadDto?> UpdateBookingAsync(int id, BookingUpdateDto bookingDto, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gọi đến endpoint của Ocelot API Gateway
            var response = await _httpClient.PutAsJsonAsync($"/booking/{id}", bookingDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error: {response.StatusCode} - {errorContent}");
                throw new Exception($"Cập nhật booking thất bại. Lỗi từ API: {errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<BookingReadDto>();
        }

        public async Task<bool> CheckSlotsAvailabilityAsync(List<BookingSlotRequest> requestedSlots, string accessToken)
        {


            AddBearerAccessToken(accessToken);
            var response = await _httpClient.PostAsJsonAsync("/bookings/checkAvailability", requestedSlots);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine(error);
                return false;
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Kiểm tra tình trạng sân thất bại. Lỗi từ API: {response.StatusCode} - {errorContent}");
        }
        public async Task<RevenueStatisticViewModel> GetRevenueStatisticsAsync(
            string accessToken, int year, int? month, int? day, int[]? stadiumIds)
        {
            AddBearerAccessToken(accessToken);

            var queryParams = new List<string> { $"year={year}" };
            if (month.HasValue) queryParams.Add($"month={month.Value}");
            if (day.HasValue) queryParams.Add($"day={day.Value}");
            if (stadiumIds != null && stadiumIds.Length > 0)
            {
                foreach (var id in stadiumIds)
                {
                    queryParams.Add($"stadiumIds={id}");
                }
            }
            var queryString = string.Join("&", queryParams);

            var response = await _httpClient.GetAsync($"/booking/statistics?{queryString}");

            if (!response.IsSuccessStatusCode)
            {
                return new RevenueStatisticViewModel();
            }

            var result = await response.Content.ReadFromJsonAsync<RevenueStatisticViewModel>();
            return result ?? new RevenueStatisticViewModel();
        }
        
        public async Task<List<StadiumBookingOverviewDto>> GetStadiumRevenueAsync(string accessToken, int page, int pageSize, int? year, int? month, int? day)
        {
            AddBearerAccessToken(accessToken);

            var queryParams = new List<string> { $"page={page}", $"pageSize={pageSize}" };
            if (year.HasValue) queryParams.Add($"year={year.Value}");
            if (month.HasValue) queryParams.Add($"month={month.Value}");
            if (day.HasValue) queryParams.Add($"day={day.Value}");

            // Thêm expand=Courts
            queryParams.Add("expand=Courts");

            var queryString = string.Join("&", queryParams);

            // Gọi đến Upstream Path của Ocelot
            var response = await _httpClient.GetAsync($"/aggregator/stadiums-bookings?{queryString}");

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error fetching stadium revenue: {error}");
                return new List<StadiumBookingOverviewDto>();
            }

            var result = await response.Content.ReadFromJsonAsync<List<StadiumBookingOverviewDto>>();
            return result ?? new List<StadiumBookingOverviewDto>();
        }
    }
}