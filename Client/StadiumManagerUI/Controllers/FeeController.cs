using DTOs.FeesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Security.Claims;

namespace StadiumManagerUI.Controllers
{
    public class FeeController : Controller
    {
        private readonly IFeesService _feesService;
        private readonly ITokenService _tokenService;
        private readonly IStadiumService _stadiumService;
        private readonly ILogger<FeeController> _logger;

        public FeeController(IFeesService feesService, ITokenService tokenService, ILogger<FeeController> logger, IStadiumService stadiumService)
        {
            _feesService = feesService;
            _tokenService = tokenService;
            _logger = logger;
            _stadiumService = stadiumService;
        }

        public IActionResult FeeManagement()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetMyFeesData([FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                var token = _tokenService.GetAccessTokenFromCookie();
                if (string.IsNullOrEmpty(token)) return Unauthorized("Token is missing.");

                // Lấy UserId của người dùng đang đăng nhập từ Session
                var ownerId = HttpContext.Session.GetInt32("UserId");
                if (ownerId == null)
                {
                    return Forbid("User ID không hợp lệ.");
                }

                // Gọi service với ownerId đã lấy được
                var feesData = await _feesService.GetFeesForOwner(token, ownerId.Value, month, year);

                // Gọi stadium service để lấy thông tin sân
                var stadiumIds = feesData.Value.Select(f => f.StadiumId).Distinct().ToList();
                var stadiums = await _stadiumService.GetAllStadiumByListId(stadiumIds);

                // Trả về danh sách các bản ghi phí
                var feesWithStadiumInfo = feesData.Value.Select(fee =>
                {
                    var stadium = stadiums.Value.FirstOrDefault(s => s.Id == fee.StadiumId);
                    return new
                    {
                        Fee = fee,
                        StadiumName = stadium != null ? stadium.Name : "Unknown Stadium"
                    };
                });

                return Ok(feesWithStadiumInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy dữ liệu cước phí cho chủ sân.");
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi lấy dữ liệu." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UploadBill([FromForm] UploadBillImageDTO uploadDto)
        {
            if (uploadDto.BillImage == null || uploadDto.BillImage.Length == 0)
            {
                return BadRequest("Vui lòng chọn một file ảnh hóa đơn.");
            }

            try
            {
                var token = _tokenService.GetAccessTokenFromCookie();
                if (string.IsNullOrEmpty(token)) return Unauthorized("Token is missing.");

                var updatedFee = await _feesService.UploadBillImage(token, uploadDto);

                if (updatedFee == null)
                {
                    return StatusCode(500, "Không thể cập nhật hóa đơn trên server.");
                }

                return Ok(updatedFee);
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "Lỗi HTTP khi upload hóa đơn cho Fee ID: {FeeId}", uploadDto.FeeId);
                return StatusCode(500, "Đã xảy ra lỗi khi kết nối đến server.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi upload hóa đơn cho Fee ID: {FeeId}", uploadDto.FeeId);
                return StatusCode(500, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
        }
    }
}
