using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs.DiscountDTO;
using DTOs.StadiumDTO;
using StadiumManagerUI.Helpers;
using DTOs.UserDTO;
using System.Linq;

namespace StadiumManagerUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IStadiumService _stadiumService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService; // Add IUserService

        public DiscountController(
            IDiscountService discountService,
            IStadiumService stadiumService,
            ITokenService tokenService,
            IUserService userService) // Inject IUserService
        {
            _discountService = discountService;
            _stadiumService = stadiumService;
            _tokenService = tokenService;
            _userService = userService; // Assign injected service
        }

        // Action này CHỈ trả về View rỗng
        public IActionResult DiscountList()
        {
            return View();
        }

        // Action này được JavaScript gọi để LẤY TẤT CẢ DỮ LIỆU discount VỚI PHÂN TRANG
        [HttpGet]
        public async Task<IActionResult> GetDiscountPageData(int page = 1, int pageSize = 5, string? searchByCode = null, int? stadiumId = null, bool? isActive = null)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Phiên đăng nhập hết hạn." });
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Unauthorized(new { message = "Phiên đăng nhập hết hạn." });
            }

            // --- LOGIC UPDATE START ---

            // 1. Lấy danh sách discount trước
            var discountsResponse = await _discountService.GetDiscountsByUserAsync(
                accessToken,
                userId,
                page,
                pageSize,
                searchByCode,
                stadiumId,
                isActive
            );

            var discounts = discountsResponse?.Value ?? new List<ReadDiscountDTO>();
            var totalCount = discountsResponse?.Count ?? 0;

            // 2. Thu thập TargetUserIds từ danh sách discount
            var targetUserIds = discounts
                .Where(d => !string.IsNullOrEmpty(d.TargetUserId) && int.TryParse(d.TargetUserId, out _))
                .Select(d => int.Parse(d.TargetUserId!))
                .Distinct()
                .ToList();

            var targetUsers = new List<PublicUserProfileDTO>();
            // 3. Gọi service để lấy thông tin user nếu có ID
            if (targetUserIds.Any())
            {
                targetUsers = await _userService.GetUsersByIdsAsync(targetUserIds, accessToken);
            }

            // 4. Lấy danh sách stadium (có thể chạy song song với việc lấy user)
            string filter = $"&$filter=CreatedBy eq {userId}";
            var stadiumsJson = await _stadiumService.SearchStadiumAsync(filter);

            // Xử lý stadium
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
                    Debug.WriteLine($"JSON Error parsing stadiums: {ex.Message}");
                }
            }

            // 5. Trả về cho client: discounts, stadiums, targetUsers, và count
            return Json(new { discounts, stadiums, targetUsers, count = totalCount });

            // --- LOGIC UPDATE END ---
        }

        // NEW ACTION to search for users
        [HttpGet]
        public async Task<IActionResult> SearchUsers(string searchTerm)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest(new { success = false, message = "Yêu cầu không hợp lệ." });
            }

            var phoneTask = _userService.SearchUsersByPhoneAsync(searchTerm, accessToken);
            var emailTask = _userService.SearchUsersByEmailAsync(searchTerm, accessToken);

            await Task.WhenAll(phoneTask, emailTask);

            var usersByPhone = phoneTask.Result;
            var usersByEmail = emailTask.Result;

            // Combine and remove duplicates
            var allUsers = usersByPhone.Concat(usersByEmail)
                                       .GroupBy(u => u.UserId)
                                       .Select(g => g.First())
                                       .ToList();

            return Json(new { success = true, users = allUsers });
        }


        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDTO dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken) || dto == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ hoặc chưa đăng nhập." });
            }

            var userId = HttpContext.Session.GetInt32("UserId");

            dto.UserId = userId + "";

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

            // Log Id, IsActive, StartDate, EndDate
            Console.WriteLine($"[CONTROLLER] UpdateDiscount - Id: {dto.Id}, IsActive: {dto.IsActive}, StartDate: {dto.StartDate:yyyy-MM-dd HH:mm:ss}, EndDate: {dto.EndDate:yyyy-MM-dd HH:mm:ss}");

            bool success = await _discountService.UpdateDiscountAsync(accessToken, dto);

            if (!success)
            {
                return StatusCode(500, new { success = false, message = "Cập nhật discount thất bại." });
            }

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

            // Log Id, IsActive, StartDate, EndDate
            Console.WriteLine($"[CONTROLLER] ToggleDiscountStatus - Id: {dto.Id}, IsActive: {dto.IsActive}, StartDate: {dto.StartDate:yyyy-MM-dd HH:mm:ss}, EndDate: {dto.EndDate:yyyy-MM-dd HH:mm:ss}");

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