using System.Text;
using System.Text.Json;
using AggregatorPatternAPI.DTOs;
using BookingAPI.DTOs; // Cần để deserialize từ BookingAPI
using StadiumAPI.DTOs;

namespace AggregatorPatternAPI.Services
{
    public class AggregatorService : IAggregatorService
    {
        private readonly HttpClient _stadiumClient;
        private readonly HttpClient _bookingClient;
        private readonly HttpClient _userClient; // THÊM HTTPCLIENT CHO USER
        private readonly ILogger<AggregatorService> _logger;

        public AggregatorService(IHttpClientFactory clientFactory, ILogger<AggregatorService> logger)
        {
            _stadiumClient = clientFactory.CreateClient("StadiumAPI");
            _bookingClient = clientFactory.CreateClient("BookingAPI");
            _userClient = clientFactory.CreateClient("UserAPI"); // KHỞI TẠO
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
    }
}