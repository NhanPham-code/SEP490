using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs.DiscountDTO;
using DTOs.StadiumDTO;
using StadiumManagerUI.Helpers;

namespace StadiumManagerUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IStadiumService _stadiumService;
        private readonly ITokenService _tokenService;

        public DiscountController(
            IDiscountService discountService,
            IStadiumService stadiumService,
            ITokenService tokenService,
            IUserService userService)
        {
            _discountService = discountService;
            _stadiumService = stadiumService;
            _tokenService = tokenService;
        }

        // Action này CHỈ trả về View rỗng
        public IActionResult DiscountList()
        {
            return View();
        }

        // Action này được JavaScript gọi để LẤY TẤT CẢ DỮ LIỆU
        [HttpGet]
        public async Task<IActionResult> GetDiscountPageData()
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Phiên đăng nhập hết hạn." });
            }

            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                // Nếu không có UserId trong session, coi như phiên không hợp lệ
                return Unauthorized(new { message = "Phiên làm việc không hợp lệ hoặc đã hết hạn." });
            }

            var discountsTask = _discountService.GetDiscountsByUserAsync(accessToken, userId);
            string filter = $"&$filter=CreatedBy eq {userId}";
            var stadiumsJsonTask = _stadiumService.SearchStadiumAsync(filter);

            await Task.WhenAll(discountsTask, stadiumsJsonTask);

            var discounts = discountsTask.Result ?? new List<ReadDiscountDTO>();
            var stadiumsJson = stadiumsJsonTask.Result;
            var stadiums = new List<ReadStadiumDTO>();

            if (!string.IsNullOrEmpty(stadiumsJson))
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    options.Converters.Add(new Iso8601TimeSpanConverter());
                    using (JsonDocument doc = JsonDocument.Parse(stadiumsJson))
                    {
                        if (doc.RootElement.TryGetProperty("value", out JsonElement valueElement))
                        {
                            stadiums = JsonSerializer.Deserialize<List<ReadStadiumDTO>>(valueElement.GetRawText(), options) ?? new List<ReadStadiumDTO>();
                        }
                    }
                }
                catch (JsonException ex)
                {
                    Debug.WriteLine($"JSON Error: {ex.Message}");
                    // Có thể xem xét trả về lỗi cho client nếu cần
                }
            }

            return Json(new { discounts, stadiums });
        }


        // === CÁC ACTION CREATE, UPDATE, TOGGLESTATUS GIỮ NGUYÊN NHƯ TRƯỚC ===
        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDTO dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken) || dto == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ hoặc chưa đăng nhập." });
            }

            var userId = HttpContext.Session.GetString("UserId");
            dto.UserId = userId;

            var createdDiscount = await _discountService.CreateDiscountAsync(accessToken, dto);

            if (createdDiscount == null)
            {
                return StatusCode(500, new { success = false, message = "Tạo discount thất bại. Mã có thể đã tồn tại." });
            }

            return Json(new { success = true, data = createdDiscount });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount([FromBody] UpdateDiscountDTO dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken) || dto == null || dto.Id == 0)
            {
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ hoặc chưa đăng nhập." });
            }

            bool success = await _discountService.UpdateDiscountAsync(accessToken, dto);

            if (!success)
            {
                return StatusCode(500, new { success = false, message = "Cập nhật discount thất bại." });
            }

            // Trả về discount đã cập nhật để client có thể render lại
            var updatedDiscount = await _discountService.GetDiscountByIdAsync(dto.Id);
            return Json(new { success = true, data = updatedDiscount });
        }

        [HttpPost]
        public async Task<IActionResult> ToggleDiscountStatus([FromBody] UpdateDiscountDTO dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken) || dto == null || dto.Id == 0)
            {
                return BadRequest(new { success = false, message = "Yêu cầu không hợp lệ." });
            }

            bool success = await _discountService.UpdateDiscountAsync(accessToken, dto);

            if (!success)
            {
                return StatusCode(500, new { success = false, message = "Thay đổi trạng thái thất bại." });
            }

            var updatedDiscount = await _discountService.GetDiscountByIdAsync(dto.Id);
            return Json(new { success = true, data = updatedDiscount });
        }
    }
}