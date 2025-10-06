using AggregatorPatternAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AggregatorPatternAPI.Controllers
{
    [ApiController]
    [Route("api/aggregator")]
    public class AggregatorController : ControllerBase
    {
        private readonly IAggregatorService _aggregatorService;
        private readonly ILogger<AggregatorController> _logger;

        public AggregatorController(IAggregatorService aggregatorService, ILogger<AggregatorController> logger)
        {
            _aggregatorService = aggregatorService;
            _logger = logger;
        }

        // THAY ĐỔI: Cập nhật action để nhận tham số mới
        [HttpGet("stadiums-bookings")]
        public async Task<IActionResult> GetStadiumsBookingOverview(
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10, 
            [FromQuery] int? year = null,
            [FromQuery] int? month = null,
            [FromQuery] int? day = null)
        {
            try
            {
                // Nếu không có bộ lọc ngày/tháng/năm nào được cung cấp, có thể đặt mặc định
                int targetYear = year ?? DateTime.UtcNow.Year;
                
                // Tuy nhiên, logic mới cho phép null, nên ta chỉ cần truyền thẳng vào
                var result = await _aggregatorService.GetStadiumsBookingOverviewAsync(page, pageSize, year, month, day);
                
                if (result == null) // Có thể trả về null nếu có lỗi
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }

                if (!result.Any())
                {
                    // Trả về mảng rỗng thay vì NotFound để client dễ xử lý
                    return Ok(Enumerable.Empty<object>());
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting stadium booking overview.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}