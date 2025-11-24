using System.Text;
using System.Text.Json;
using AggregatorPatternAPI.DTOs;
using BookingAPI.DTOs; // Cần để deserialize từ BookingAPI
using Microsoft.Extensions.Caching.Distributed;
using StadiumAPI.DTOs;

namespace AggregatorPatternAPI.Services
{
    public class AggregatorService : IAggregatorService
    {
        private readonly HttpClient _stadiumClient;
        private readonly HttpClient _bookingClient;
        private readonly HttpClient _userClient; // THÊM HTTPCLIENT CHO USER
        private readonly HttpClient _feedbackClient;
        private readonly ILogger<AggregatorService> _logger;

        public AggregatorService(IHttpClientFactory clientFactory, ILogger<AggregatorService> logger)
        {
            _stadiumClient = clientFactory.CreateClient("StadiumAPI");
            _bookingClient = clientFactory.CreateClient("BookingAPI");
            _userClient = clientFactory.CreateClient("UserAPI"); // KHỞI TẠO
            _feedbackClient = clientFactory.CreateClient("FeedbackAPI");
            _logger = logger;
        }

        public async Task<IEnumerable<StadiumBookingOverviewDto>> GetStadiumsBookingOverviewAsync(int page, int pageSize, int? year, int? month, int? day)
        {
            // 1. Lấy sân vận động (đã bao gồm Courts)
            var stadiums = await GetStadiumsAsync(page, pageSize);
            if (stadiums == null || !stadiums.Any()) return Enumerable.Empty<StadiumBookingOverviewDto>();

            var stadiumIds = stadiums.Select(s => s.Id).ToList();

            // 2. Lấy booking
            var bookings = await GetBookingsForStadiumsAsync(stadiumIds, year, month, day);

            // 3. Lấy thông tin người dùng từ các booking
            var userIds = bookings.Select(b => b.UserId).Distinct().ToList();
            var users = new Dictionary<int, UserProfileDto>();
            if (userIds.Any())
            {
                users = await GetUsersAsync(userIds);
            }

            // 4. Nhóm booking theo sân và làm giàu dữ liệu
            var bookingsByStadium = bookings.GroupBy(b => b.StadiumId);
            var result = new List<StadiumBookingOverviewDto>();

            foreach (var stadium in stadiums)
            {
                var overview = new StadiumBookingOverviewDto
                {
                    StadiumId = stadium.Id,
                    StadiumName = stadium.Name,
                    Courts = stadium.Courts?.ToList() ?? new List<ReadCourtDTO>(),
                    Bookings = new List<EnrichedBookingDto>(),
                    CompletedBookingsCount = 0,
                    TotalRevenue = 0,
                    TotalOriginRevenue = 0,
                };

                var stadiumBookings = bookings.Where(b => b.StadiumId == stadium.Id).ToList();
                if (stadiumBookings.Any())
                {
                    var enrichedBookings = stadiumBookings.Select(b => new EnrichedBookingDto
                    {
                        // Sao chép các thuộc tính từ BookingReadDto
                        Id = b.Id,
                        UserId = b.UserId,
                        Status = b.Status,
                        Date = b.Date,
                        TotalPrice = b.TotalPrice,
                        OriginalPrice = b.OriginalPrice,
                        Note = b.Note,
                        PaymentMethod = b.PaymentMethod,
                        CreatedAt = b.CreatedAt,
                        UpdatedAt = b.UpdatedAt,
                        StadiumId = b.StadiumId,
                        MonthlyBookingId = b.MonthlyBookingId,
                        BookingDetails = b.BookingDetails,
                        // Làm giàu thông tin User
                        User = users.TryGetValue(b.UserId, out var userProfile) ? userProfile : new UserProfileDto { UserId = b.UserId, FullName = "N/A" }
                    }).ToList();

                    overview.Bookings = enrichedBookings;
                    var completedBookings = enrichedBookings.Where(b => b.Status.Equals("completed", StringComparison.OrdinalIgnoreCase)).ToList();
                    overview.CompletedBookingsCount = completedBookings.Count;
                    overview.TotalRevenue = completedBookings.Sum(b => b.TotalPrice ?? 0);
                    overview.TotalOriginRevenue = completedBookings.Sum(b => b.OriginalPrice ?? 0);
                }
                
                result.Add(overview);
            }
            
            _logger.LogInformation("Successfully aggregated data for {StadiumCount} stadiums.", result.Count);
            return result;
        }

        private async Task<List<StadiumDto>> GetStadiumsAsync(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var response = await _stadiumClient.GetAsync($"odata/OdataStadium?$skip={skip}&$top={pageSize}&$select=Id,Name&$expand=Courts&$orderby=Id");
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch stadiums. Status: {StatusCode}", response.StatusCode);
                return new List<StadiumDto>();
            }

            var content = await response.Content.ReadAsStringAsync();
            var odataResponse = JsonSerializer.Deserialize<ODataResponse<StadiumDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return odataResponse?.Value ?? new List<StadiumDto>();
        }
        
        // Phương thức này vẫn trả về DTO gốc từ BookingAPI
        private async Task<List<BookingReadDto>> GetBookingsForStadiumsAsync(List<int> stadiumIds, int? year, int? month, int? day)
        {
            var queryBuilder = new StringBuilder();
            foreach (var id in stadiumIds) { queryBuilder.Append($"stadiumIds={id}&"); }
            if (year.HasValue) { queryBuilder.Append($"year={year.Value}&"); }
            if (month.HasValue) { queryBuilder.Append($"month={month.Value}&"); }
            if (day.HasValue) { queryBuilder.Append($"day={day.Value}&"); }
            if (queryBuilder.Length > 0) { queryBuilder.Length--; }

            var requestUri = $"api/booking/by-stadiums-and-date?{queryBuilder}";
            var response = await _bookingClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch bookings. Status: {StatusCode}, Uri: {RequestUri}", response.StatusCode, requestUri);
                return new List<BookingReadDto>();
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<BookingReadDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<BookingReadDto>();
        }

        // PHƯƠNG THỨC MỚI ĐỂ LẤY USER
        private async Task<Dictionary<int, UserProfileDto>> GetUsersAsync(List<int> userIds)
        {
            if (userIds == null || !userIds.Any())
            {
                return new Dictionary<int, UserProfileDto>();
            }

            var filterQuery = string.Join(" or ", userIds.Select(id => $"UserId eq {id}"));
            var requestUri = $"odata/ODataUsers?$filter={filterQuery}";

            var response = await _userClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch users. Status: {StatusCode}, Uri: {RequestUri}", response.StatusCode, requestUri);
                return new Dictionary<int, UserProfileDto>();
            }

            var content = await response.Content.ReadAsStringAsync();
            var odataResponse = JsonSerializer.Deserialize<ODataResponse<UserProfileDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            return odataResponse?.Value?.ToDictionary(u => u.UserId) ?? new Dictionary<int, UserProfileDto>();
        }

        // Lấy danh sách stadium theo userId bằng OData
        private async Task<List<StadiumIdAndNameDto>> GetStadiumsByUserIdAsync(int userId)
        {
            // Thay đổi $select=Id thành $select=Id,Name
            var requestUrl = $"odata/OdataStadium?$filter=CreatedBy eq {userId}&$select=Id,Name";
            var response = await _stadiumClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch stadium IDs and Names for user {UserId}. Status: {StatusCode}", userId, response.StatusCode);
                return new List<StadiumIdAndNameDto>(); // Trả về danh sách rỗng
            }

            var content = await response.Content.ReadAsStringAsync();

            // Deserialize vào DTO mới
            var odataResponse = JsonSerializer.Deserialize<ODataResponse<StadiumIdAndNameDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return odataResponse?.Value ?? new List<StadiumIdAndNameDto>();
        }

        // Lấy danh sách feedback theo stadiumId bằng OData
        private async Task<List<ReadFeedbackDTO>> GetFeedbacksForStadiumsAsync(List<int> stadiumIds)
        {
            if (stadiumIds == null || !stadiumIds.Any())
            {
                return new List<ReadFeedbackDTO>();
            }

            // Chuyển danh sách ID thành chuỗi "3,4,5,16,22,23"
            var stadiumIdsString = string.Join(",", stadiumIds);

            // Xây dựng URL OData với toán tử 'in'
            // Bỏ '$top=5' và sắp xếp theo ngày tạo để lấy các feedback mới nhất trước
            var requestUrl = $"odata/FeedbackOData?$filter=StadiumId in ({stadiumIdsString})&$orderby=CreatedAt desc";

            var response = await _feedbackClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch feedbacks for multiple stadiums. Status: {StatusCode}", response.StatusCode);
                return new List<ReadFeedbackDTO>();
            }

            var content = await response.Content.ReadAsStringAsync();
            var odataResponse = JsonSerializer.Deserialize<OdataHaveCountResponse<ReadFeedbackDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return odataResponse?.Value ?? new List<ReadFeedbackDTO>();
        }

        // lấy thống kê về booking (số lượng thành công, thất bại, tổng danh thu,..) theo stadiumIds từ BookingAPI
        private async Task<DTOs.RichStadiumKpiDto?> GetBookingKpiAsync(List<int> stadiumIds)
        {
            var empty = new DTOs.RichStadiumKpiDto();
            if (stadiumIds == null || !stadiumIds.Any()) return empty;

            var queryString = string.Join("&", stadiumIds.Select(id => $"stadiumIds={id}"));
            var requestUrl = $"api/booking/summary/kpi?{queryString}";

            try
            {
                var response = await _bookingClient.GetAsync(requestUrl);

                // nếu non-success, log cả status + body (nếu có) để dễ debug
                if (!response.IsSuccessStatusCode)
                {
                    string respBody = string.Empty;
                    try
                    {
                        respBody = await response.Content.ReadAsStringAsync();
                    }
                    catch (Exception readEx)
                    {
                        _logger.LogWarning(readEx, "Failed to read BookingAPI response body for URL {Url}", requestUrl);
                    }

                    _logger.LogError("Failed to fetch booking KPIs for stadiums. Status: {StatusCode}, URL: {Url}, Body: {Body}",
                        response.StatusCode, requestUrl, string.IsNullOrWhiteSpace(respBody) ? "<empty>" : respBody);

                    // Trả fallback rỗng thay vì null để tránh làm sập toàn bộ dashboard
                    return empty;
                }

                var content = await response.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<DTOs.RichStadiumKpiDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return dto ?? empty;
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "HttpRequestException when calling BookingAPI: {Url}", requestUrl);
                return empty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception when calling BookingAPI: {Url}", requestUrl);
                return empty;
            }
        }

        // tổng hợp dữ liệu từ các đầu api để hoàn thành StadiumManagerDashboardDto
        public async Task<StadiumManagerDashboardDto?> GetStadiumManagerDashboardAsync(int userId)
        {
            // 1. Lấy danh sách STADIUMS
            var managedStadiums = await GetStadiumsByUserIdAsync(userId);
            if (managedStadiums == null || !managedStadiums.Any())
            {
                _logger.LogWarning("User {UserId} does not manage any stadiums.", userId);
                return new StadiumManagerDashboardDto();
            }
            var stadiumIdToNameMap = managedStadiums.ToDictionary(s => s.Id, s => s.Name);
            var stadiumIds = managedStadiums.Select(s => s.Id).ToList();

            // 2. Gọi song song để lấy KPI và Feedback
            //    *** THAY ĐỔI QUAN TRỌNG Ở ĐÂY ***
            var kpiTask = GetBookingKpiAsync(stadiumIds);
            var feedbackTask = GetFeedbacksForStadiumsAsync(stadiumIds); // <--- Chỉ còn 1 task duy nhất!

            // Chờ cả hai tác vụ độc lập hoàn thành
            await Task.WhenAll(kpiTask, feedbackTask);

            var kpiResult = await kpiTask;
            var allFeedbacks = await feedbackTask; // <--- Lấy kết quả từ 1 task

            if (kpiResult == null)
            {
                _logger.LogError("Could not generate dashboard for user {UserId} because KPI fetching failed.", userId);
                return null;
            }

            // 3. Làm giàu dữ liệu FEEDBACK
            var enrichedFeedbacks = new List<EnrichedFeedbackDto>();
            if (allFeedbacks.Any())
            {
                var userIdsFromFeedbacks = allFeedbacks.Select(f => f.UserId).Distinct().ToList();
                var users = await GetUsersAsync(userIdsFromFeedbacks);

                foreach (var feedback in allFeedbacks)
                {
                    users.TryGetValue(feedback.UserId, out var userProfile);
                    stadiumIdToNameMap.TryGetValue(feedback.StadiumId, out var stadiumName);

                    enrichedFeedbacks.Add(new EnrichedFeedbackDto
                    {
                        // ... (sao chép các thuộc tính) ...
                        Id = feedback.Id,
                        UserId = feedback.UserId,
                        StadiumId = feedback.StadiumId,
                        Rating = feedback.Rating,
                        Comment = feedback.Comment,
                        ImagePath = feedback.ImagePath,
                        CreatedAt = feedback.CreatedAt,
                        User = userProfile ?? new UserProfileDto { UserId = feedback.UserId },
                        StadiumName = stadiumName ?? "Sân không xác định"
                    });
                }
            }

            // 4. Xây dựng đối tượng DTO trả về
            var dashboardDto = new StadiumManagerDashboardDto
            {
                ManagedStadiumsCount = stadiumIds.Count,
                SuccessfulBookings = kpiResult.SuccessfulBookings,
                FailedBookings = kpiResult.FailedBookings,
                BookingsToday = kpiResult.BookingsToday,
                RevenueToday = kpiResult.RevenueToday,
                WeeklyRevenueChartData = kpiResult.WeeklyRevenueData,
                BookingStatusChartData = kpiResult.BookingStatusData,
                // Dữ liệu feedback đã được sắp xếp từ API, chỉ cần lấy 5 cái đầu tiên
                LatestFeedbacks = enrichedFeedbacks.Take(5).ToList()
            };

            return dashboardDto;
        }

        // lấy số lượng sân bằng odata
        private async Task<int> GetTotalStadiumCountAsync()
        {
            var response = await _stadiumClient.GetAsync("odata/OdataStadium?$count=true&$top=0");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch total stadium count. Status: {StatusCode}", response.StatusCode);
                return 0;
            }

            var content = await response.Content.ReadAsStringAsync();
            //var odataResponse = JsonSerializer.Deserialize<OdataHaveCountResponse<StadiumIdAndNameDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var odataResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<OdataHaveCountResponse<StadiumIdAndNameDto>>(content);
            return odataResponse?.Count ?? 0;
        }

        // lấy số lượng feedback bằng odata
        private async Task<int> GetTotalFeedbackCountAsync()
        {
            var response = await _feedbackClient.GetAsync("odata/FeedbackOData?$count=true&$top=0");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch total feedback count. Status: {StatusCode}", response.StatusCode);
                return 0;
            }

            var content = await response.Content.ReadAsStringAsync();
            //var odataResponse = JsonSerializer.Deserialize<OdataHaveCountResponse<ReadFeedbackDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var odataResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<OdataHaveCountResponse<ReadFeedbackDTO>>(content);
            return odataResponse?.Count ?? 0;
        }

        // lấy user statistic
        private async Task<UserStatisticsDto> GetUserStatisticsAsync()
        {
            var response = await _userClient.GetAsync("api/Users/statistics");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch user statistics. Status: {StatusCode}", response.StatusCode);
                return new UserStatisticsDto();
            }

            var content = await response.Content.ReadAsStringAsync();
            var userStats = JsonSerializer.Deserialize<UserStatisticsDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return userStats ?? new UserStatisticsDto();
        }

        // lấy booking statistic
        private async Task<DTOs.BookingStatisticsDto> GetBookingStatisticsAsync()
        {
            var response = await _bookingClient.GetAsync("api/Booking/summary/statistics");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch booking statistics. Status: {StatusCode}", response.StatusCode);
                return new DTOs.BookingStatisticsDto();
            }

            var content = await response.Content.ReadAsStringAsync();
            var bookingStats = JsonSerializer.Deserialize<DTOs.BookingStatisticsDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return bookingStats ?? new DTOs.BookingStatisticsDto();
        }


        // tổng hợp dữ liệu cho dashboard admin
        public async Task<AdminDashboardDto> GetAdminDashboardAsync()
        {
            // 1. Gọi tất cả các hàm helper song song để tối ưu hiệu năng
            var userStatsTask = GetUserStatisticsAsync();
            var bookingStatsTask = GetBookingStatisticsAsync();
            var totalStadiumsTask = GetTotalStadiumCountAsync();
            var totalFeedbacksTask = GetTotalFeedbackCountAsync();

            try
            {
                // Chờ tất cả các cuộc gọi API hoàn thành
                await Task.WhenAll(userStatsTask, bookingStatsTask, totalStadiumsTask, totalFeedbacksTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "One or more API calls failed while gathering data for Admin Dashboard.");
                return null; // Trả về null nếu có lỗi nghiêm trọng
            }

            // 2. Lấy kết quả từ các task đã hoàn thành
            var userStats = await userStatsTask;
            var bookingStats = await bookingStatsTask;
            var totalStadiums = await totalStadiumsTask;
            var totalFeedbacks = await totalFeedbacksTask;

            // 3. Tính toán các chỉ số phụ (phần trăm thay đổi)
            decimal newUserChangePercentage = (userStats.NewUsersLastMonth > 0)
                ? ((decimal)(userStats.NewUsersThisMonth - userStats.NewUsersLastMonth) / userStats.NewUsersLastMonth) * 100
                : (userStats.NewUsersThisMonth > 0 ? 100 : 0);

            decimal revenueChangePercentage = (bookingStats.RevenueLastMonth > 0)
                ? ((bookingStats.RevenueThisMonth - bookingStats.RevenueLastMonth) / bookingStats.RevenueLastMonth) * 100
                : (bookingStats.RevenueThisMonth > 0 ? 100 : 0);

            // 4. Tạo DTO cuối cùng để trả về cho client
            var dashboardDto = new AdminDashboardDto
            {
                // Dữ liệu cho các thẻ KPI
                TotalUsers = userStats.TotalUsers,
                NewUsersChangePercentage = Math.Round(newUserChangePercentage, 1),

                RevenueThisMonth = bookingStats.RevenueThisMonth,
                RevenueChangePercentage = Math.Round(revenueChangePercentage, 1),

                // Thay thế cho thẻ "Mã giảm giá"
                TotalStadiums = totalStadiums,
                // Thay thế cho thẻ "Đánh giá mới"
                TotalFeedbacks = totalFeedbacks,

                // Dữ liệu cho các biểu đồ
                RevenueLast6Months = bookingStats.RevenueLast6Months,
                NewUsersLast6Months = userStats.NewUsersLast6Months
            };

            return dashboardDto;
        }
    }
}