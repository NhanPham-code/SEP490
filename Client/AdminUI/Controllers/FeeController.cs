using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    public class FeeController : Controller
    {
        private readonly IFeesService _feesService;
        private readonly ITokenService _tokenService;
        private readonly IStadiumService _stadiumService;
        private readonly IUserService _userService;
        private readonly ILogger<FeeController> _logger;

        public FeeController(IFeesService feesService, ILogger<FeeController> logger, ITokenService tokenService, IStadiumService stadiumService, IUserService userService)
        {
            _feesService = feesService;
            _logger = logger;
            _tokenService = tokenService;
            _stadiumService = stadiumService;
            _userService = userService;
        }

        // Action để hiển thị trang quản lý
        public IActionResult FeeManagement()
        {
            return View();
        }

        /// <summary>
        /// API endpoint để lấy dữ liệu phí dựa trên các bộ lọc.
        /// Được gọi bởi JavaScript.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetFeesData([FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                // Lấy token từ HttpContext (giả sử nó được lưu trong cookie hoặc session)
                var token = _tokenService.GetAccessTokenFromCookie();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Token is missing.");
                }

                // Gọi dịch vụ để lấy dữ liệu cước phí
                var fees = await _feesService.GetFeesByMonthYearAsync(month, year, token);
                if (fees == null)
                {
                    return NotFound("Không tìm thấy dữ liệu cước phí.");
                }

                // Gọi dịch vụ để lấy danh sách sân và chủ sân
                var stadiumIds = fees.Select(f => f.StadiumId).Distinct().ToList();
                var stadiums = await _stadiumService.GetAllStadiumByListId(stadiumIds);

                // Lấy danh sách chủ sân
                var ownerIds = stadiums.Value.Select(s => s.Id).Distinct().ToList();
                var owners = await _userService.GetUsersByIdsAsync(ownerIds, token);

                // Kết hợp dữ liệu để trả về
                var result = fees.Select(fee =>
                {
                    var stadium = stadiums.Value.FirstOrDefault(s => s.Id == fee.StadiumId);
                    var owner = owners.FirstOrDefault(o => o.UserId == stadium?.CreatedBy);

                    return new
                    {
                        Fee = fee,
                        StadiumName = stadium?.Name,
                        OwnerName = owner != null ? $"{owner.FullName}" : "N/A"
                    };
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy dữ liệu cước phí cho tháng {Month}/{Year}", month, year);
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi lấy dữ liệu cước phí." });
            }
        }

        /// <summary>
        /// API endpoint để cập nhật trạng thái thanh toán của một cước phí.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> ConfirmPayment(int feeId)
        {
            if (feeId <= 0)
            {
                return BadRequest("Fee ID không hợp lệ.");
            }

            try
            {
                var token = _tokenService.GetAccessTokenFromCookie();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Token is missing.");
                }

                var updatedFee = await _feesService.UpdateFeeToPaidAsync(feeId, token);
                return Ok(updatedFee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xác nhận thanh toán cho Fee ID: {FeeId}", feeId);
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi xác nhận thanh toán." });
            }
        }
    }
}
