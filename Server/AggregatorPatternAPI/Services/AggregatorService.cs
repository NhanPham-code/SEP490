using System.Text;
using System.Text.Json;
using AggregatorPatternAPI.DTOs;
using BookingAPI.DTOs;
using StadiumAPI.DTOs;

namespace AggregatorPatternAPI.Services
{
    public class AggregatorService : IAggregatorService
    {
        private readonly HttpClient _stadiumClient;
        private readonly HttpClient _bookingClient;
        private readonly ILogger<AggregatorService> _logger;

        public AggregatorService(IHttpClientFactory clientFactory, ILogger<AggregatorService> logger)
        {
            _stadiumClient = clientFactory.CreateClient("StadiumAPI");
            _bookingClient = clientFactory.CreateClient("BookingAPI");
            _logger = logger;
        }

        public async Task<IEnumerable<StadiumBookingOverviewDto>> GetStadiumsBookingOverviewAsync(int page, int pageSize, int? year, int? month, int? day)
        {
            // 1. Lấy sân vận động (không đổi)
            _logger.LogInformation("Fetching stadiums for page {Page} and page size {PageSize}", page, pageSize);
            var stadiums = await GetStadiumsAsync(page, pageSize);
            if (stadiums == null || !stadiums.Any())
            {
                return Enumerable.Empty<StadiumBookingOverviewDto>();
            }

            var stadiumIds = stadiums.Select(s => s.Id).ToList();

            // 2. Lấy booking với các tham số mới
            _logger.LogInformation("Fetching bookings for {StadiumCount} stadiums. Filter: [Year: {Year}, Month: {Month}, Day: {Day}]", stadiumIds.Count, year, month, day);
            var bookings = await GetBookingsForStadiumsAsync(stadiumIds, year, month, day);

            // 3 & 4. Tổng hợp dữ liệu (không đổi)
            var bookingsByStadium = bookings.GroupBy(b => b.StadiumId).ToDictionary(g => g.Key, g => g.ToList());
            var result = new List<StadiumBookingOverviewDto>();
            foreach (var stadium in stadiums)
            {
                var overview = new StadiumBookingOverviewDto
                {
                    StadiumId = stadium.Id,
                    StadiumName = stadium.Name,
                    Courts = stadium.Courts?.ToList() ?? new List<ReadCourtDTO>()
                };

                if (bookingsByStadium.TryGetValue(stadium.Id, out var stadiumBookings))
                {
                    var completedBookings = stadiumBookings.Where(b => b.Status == "completed").ToList();
                    
                    overview.Bookings = stadiumBookings;
                    overview.CompletedBookingsCount = completedBookings.Count;
                    overview.TotalRevenue = completedBookings.Sum(b => b.TotalPrice ?? 0);
                }
                else
                {
                    overview.CompletedBookingsCount = 0;
                    overview.TotalRevenue = 0;
                    overview.Bookings = new List<BookingReadDto>();
                }
                result.Add(overview);
            }
            _logger.LogInformation("Successfully aggregated data for {StadiumCount} stadiums.", result.Count);
            return result;
        }
        
        private async Task<List<StadiumDto>> GetStadiumsAsync(int page, int pageSize)
        {
            // Sử dụng OData để phân trang
            var skip = (page - 1) * pageSize;
            var response = await _stadiumClient.GetAsync($"odata/OdataStadium?$skip={skip}&$top={pageSize}&$select=Id,Name&$expand=Courts&$orderby=Id");
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch stadiums. Status: {StatusCode}", response.StatusCode);
                return new List<StadiumDto>();
            }

            var content = await response.Content.ReadAsStringAsync();
            // OData thường trả về một object chứa 'value' là mảng kết quả
            var odataResponse = JsonSerializer.Deserialize<ODataResponse<StadiumDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return odataResponse?.Value ?? new List<StadiumDto>();
        }
        
        private async Task<List<BookingReadDto>> GetBookingsForStadiumsAsync(List<int> stadiumIds, int? year, int? month, int? day)
        {
            var queryBuilder = new StringBuilder();

            // Thêm stadiumIds
            foreach (var id in stadiumIds)
            {
                queryBuilder.Append($"stadiumIds={id}&");
            }

            // Thêm các tham số ngày tháng năm nếu có
            if (year.HasValue)
            {
                queryBuilder.Append($"year={year.Value}&");
            }
            if (month.HasValue)
            {
                queryBuilder.Append($"month={month.Value}&");
            }
            if (day.HasValue)
            {
                queryBuilder.Append($"day={day.Value}&");
            }

            // Xóa dấu '&' cuối cùng nếu có
            if (queryBuilder.Length > 0)
            {
                queryBuilder.Length--; 
            }

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
    }
}
