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
using DTOs.NotificationDTO;
using System;

namespace StadiumManagerUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IStadiumService _stadiumService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IFavoriteStadiumService _favoriteStadiumService;
        private readonly INotificationService _notificationService;

        public DiscountController(
            IDiscountService discountService,
            IStadiumService stadiumService,
            ITokenService tokenService,
            IUserService userService,
            IFavoriteStadiumService favoriteStadiumService,
            INotificationService notificationService)
        {
            _discountService = discountService;
            _stadiumService = stadiumService;
            _tokenService = tokenService;
            _userService = userService;
            _favoriteStadiumService = favoriteStadiumService;
            _notificationService = notificationService;
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

            try
            {
                // Gọi hàm helper để xử lý logic gửi thông báo phức tạp
                await SendNotificationForNewDiscount(createdDiscount, accessToken);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nhưng không làm ảnh hưởng đến luồng chính
                Console.WriteLine($"[NotificationError] Failed to send notification for new discount {createdDiscount.Code}: {ex.Message}");
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

        // --- HÀM HELPER ĐÃ ĐƯỢC CẬP NHẬT VỚI LOGIC IF/ELSE ---
        private async Task SendNotificationForNewDiscount(ReadDiscountDTO discount, string accessToken)
        {
            // Lấy tên các sân áp dụng (dùng chung cho cả hai loại)
            var stadiumNames = new List<string>();
            if (discount.StadiumIds.Any())
            {
                foreach (var stadiumId in discount.StadiumIds)
                {
                    var stadium = await _stadiumService.GetStadiumByIdAsync(stadiumId);
                    if (stadium != null) stadiumNames.Add(stadium.Name);
                }
            }
            string appliedStadiums = stadiumNames.Any() ? string.Join(", ", stadiumNames) : "các sân được chọn";

            // Trường hợp 1: Gửi cho người dùng cụ thể (UNIQUE)
            if ("Unique".Equals(discount.CodeType, StringComparison.OrdinalIgnoreCase) && int.TryParse(discount.TargetUserId, out int targetUserId))
            {
                var notification = new NotificationDTO
                {
                    UserId = targetUserId,
                    Type = "Discount.New",
                    Title = "Bạn có mã giảm giá cá nhân!",
                    Message = $"Bạn nhận được mã giảm giá cá nhân: {discount.Code}, áp dụng cho sân: '{appliedStadiums}'. Mã này chỉ dành riêng cho bạn!",
                    Parameters = JsonSerializer.Serialize(new { discountCode = discount.Code }),
                    CreatedAt = DateTime.UtcNow,
                };
                Console.WriteLine($"[BACKEND-CONTROLLER] 🟡 Bước 1: Chuẩn bị gửi thông báo cho UserId = {notification.UserId}");

                await _notificationService.SendNotificationToUserAsync(notification); // Giả sử hàm này gọi API

                Console.WriteLine($"[BACKEND-CONTROLLER] 🟢 Đã gọi xong service gửi thông báo cho UserId = {notification.UserId}");
            }
            // Trường hợp 2: Gửi cho người yêu thích sân (STADIUM)
            else if ("Stadium".Equals(discount.CodeType, StringComparison.OrdinalIgnoreCase) && discount.StadiumIds.Any())
            {
                var userIdsToNotify = new HashSet<int>();
                foreach (var stadiumId in discount.StadiumIds)
                {
                    var favorites = await _favoriteStadiumService.GetFavoritesByStadiumIdAsync(stadiumId, accessToken);
                    foreach (var fav in favorites)
                    {
                        userIdsToNotify.Add(fav.UserId);
                    }
                }

                if (!userIdsToNotify.Any()) return;

                foreach (var userId in userIdsToNotify)
                {
                    var notification = new NotificationDTO
                    {
                        UserId = userId,
                        Type = "Discount.New",
                        Title = "Sân bạn yêu thích có mã giảm giá mới!",
                        Message = $"Sân '{appliedStadiums}' bạn yêu thích vừa có mã giảm giá mới: {discount.Code}. Hãy sử dụng ngay!",
                        Parameters = JsonSerializer.Serialize(new { discountCode = discount.Code }),
                        CreatedAt = DateTime.Now,
                    };
                    Console.WriteLine($"[BACKEND-CONTROLLER] 🟡 Bước 1: Chuẩn bị gửi thông báo cho UserId = {notification.UserId}");

                    await _notificationService.SendNotificationToAll(notification); // Giả sử hàm này gọi API

                    Console.WriteLine($"[BACKEND-CONTROLLER] 🟢 Đã gọi xong service gửi thông báo cho UserId = {notification.UserId}");
                }
            }
        }
    }
}