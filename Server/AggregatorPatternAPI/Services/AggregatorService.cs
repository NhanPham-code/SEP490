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
        private async Task<OdataHaveCountResponse<ReadFeedbackDTO>> GetFeedbacksByStadiumIdAsync(int stadiumId)
        {
            var response = await _feedbackClient.GetAsync($"odata?$filter=StadiumId eq {stadiumId}&$top = 5&$order by CreatedAt");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch feedbacks for stadium {StadiumId}. Status: {StatusCode}", stadiumId, response.StatusCode);
                return new OdataHaveCountResponse<ReadFeedbackDTO>();
            }

            var content = await response.Content.ReadAsStringAsync();
            var odataResponse = JsonSerializer.Deserialize<OdataHaveCountResponse<ReadFeedbackDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return odataResponse ?? new OdataHaveCountResponse<ReadFeedbackDTO>();
        }

        // lấy thống kê về booking (số lượng thành công, thất bại, tổng danh thu,..) theo stadiumIds từ BookingAPI
        private async Task<DTOs.RichStadiumKpiDto?> GetBookingKpiAsync(List<int> stadiumIds)
        {
            if (stadiumIds == null || !stadiumIds.Any())
            {
                return new DTOs.RichStadiumKpiDto(); // Trả về đối tượng rỗng nếu không có ID
            }

            // Xây dựng query string: &stadiumIds=1&stadiumIds=2...
            var queryString = string.Join("&", stadiumIds.Select(id => $"stadiumIds={id}"));
            var requestUrl = $"api/booking/summary/kpi?{queryString}";

            var response = await _bookingClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch booking KPIs for stadiums. Status: {StatusCode}, URL: {Url}", response.StatusCode, requestUrl);
                return null; // Trả về null để báo hiệu lỗi
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DTOs.RichStadiumKpiDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // tổng hợp dữ liệu từ các đầu api để hoàn thành StadiumManagerDashboardDto
        public async Task<StadiumManagerDashboardDto?> GetStadiumManagerDashboardAsync(int userId)
        {
            // 1. Lấy danh sách STADIUMS (bao gồm ID và NAME) mà người dùng này quản lý
            var managedStadiums = await GetStadiumsByUserIdAsync(userId);
            if (managedStadiums == null || !managedStadiums.Any())
            {
                _logger.LogWarning("User {UserId} does not manage any stadiums.", userId);
                return new StadiumManagerDashboardDto();
            }
            // Chuyển đổi sang Dictionary để tra cứu nhanh hơn (Key: stadiumId, Value: stadiumName)
            var stadiumIdToNameMap = managedStadiums.ToDictionary(s => s.Id, s => s.Name);
            var stadiumIds = managedStadiums.Select(s => s.Id).ToList();

            // 2. Gọi song song để lấy KPI và Feedback
            var kpiTask = GetBookingKpiAsync(stadiumIds);
            var feedbackTasks = stadiumIds.Select(id => GetFeedbacksByStadiumIdAsync(id)).ToList();

            await Task.WhenAll(kpiTask, Task.WhenAll(feedbackTasks));

            var kpiResult = await kpiTask;
            if (kpiResult == null)
            {
                _logger.LogError("Could not generate dashboard for user {UserId} because KPI fetching failed.", userId);
                return null;
            }

            // 3. Tổng hợp và LÀM GIÀU DỮ LIỆU FEEDBACK
            var allFeedbacks = new List<ReadFeedbackDTO>();
            foreach (var feedbackTask in feedbackTasks)
            {
                var feedbackResult = await feedbackTask;
                if (feedbackResult?.Value != null) allFeedbacks.AddRange(feedbackResult.Value);
            }

            var enrichedFeedbacks = new List<EnrichedFeedbackDto>();
            if (allFeedbacks.Any())
            {
                var userIdsFromFeedbacks = allFeedbacks.Select(f => f.UserId).Distinct().ToList();
                var users = await GetUsersAsync(userIdsFromFeedbacks);

                foreach (var feedback in allFeedbacks)
                {
                    // Lấy tên user và tên sân từ các dữ liệu đã thu thập
                    users.TryGetValue(feedback.UserId, out var userProfile);
                    stadiumIdToNameMap.TryGetValue(feedback.StadiumId, out var stadiumName);

                    enrichedFeedbacks.Add(new EnrichedFeedbackDto
                    {
                        // Sao chép thuộc tính gốc
                        Id = feedback.Id,
                        UserId = feedback.UserId,
                        StadiumId = feedback.StadiumId,
                        Rating = feedback.Rating,
                        Comment = feedback.Comment,
                        ImagePath = feedback.ImagePath,
                        CreatedAt = feedback.CreatedAt,

                        // Gán dữ liệu đã làm giàu
                        User = userProfile ?? new UserProfileDto { UserId = feedback.UserId },
                        StadiumName = stadiumName ?? "Sân không xác định" // Gán tên sân
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
                LatestFeedbacks = enrichedFeedbacks.OrderByDescending(f => f.CreatedAt).Take(5).ToList()
            };

            return dashboardDto;
        }
    }
}