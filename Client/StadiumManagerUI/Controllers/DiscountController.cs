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
using Microsoft.AspNetCore.Http; // Đảm bảo bạn có using này

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

            dto.UserId = userId;

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

        // --- HÀM HELPER (KHÔNG THAY ĐỔI VÌ SERVICE ĐÃ ĐƯỢC "NGỤY TRANG") ---
        private async Task SendNotificationForNewDiscount(ReadDiscountDTO discount, string accessToken)
        {
            // Trường hợp 1: Gửi cho người dùng cụ thể (UNIQUE)
            if ("Unique".Equals(discount.CodeType, StringComparison.OrdinalIgnoreCase) && int.TryParse(discount.TargetUserId, out int targetUserId) && targetUserId > 0)
            {
                // Lấy tên sân (chỉ cần khi gửi Unique)
                var uniqueStadiumNames = new List<string>();
                if (discount.StadiumIds != null && discount.StadiumIds.Any())
                {
                    foreach (var stadiumId in discount.StadiumIds)
                    {
                        try
                        {
                            var stadium = await _stadiumService.GetStadiumByIdAsync(stadiumId);
                            if (stadium != null) uniqueStadiumNames.Add(stadium.Name);
                        }
                        catch (Exception ex) { Console.WriteLine($"[NotificationError] Lỗi khi lấy tên sân {stadiumId} cho Unique: {ex.Message}"); }
                    }
                }
                string uniqueAppliedStadiums = uniqueStadiumNames.Any() ? string.Join(", ", uniqueStadiumNames) : "các sân được chọn";

                var notification = new CreateNotificationDto
                {
                    UserId = targetUserId,
                    Type = "Discount.New",
                    Title = "Bạn có mã giảm giá cá nhân!",
                    Message = $"Bạn nhận được mã giảm giá cá nhân: {discount.Code}, áp dụng cho sân: '{uniqueAppliedStadiums}'. Mã này chỉ dành riêng cho bạn!",
                    Parameters = JsonSerializer.Serialize(new { discountCode = discount.Code }),
                };
                Console.WriteLine($"[BACKEND-CONTROLLER] [Unique] 🟡 Bước 1: Chuẩn bị gửi thông báo cho UserId = {notification.UserId}");

                try
                {
                    await _notificationService.SendNotificationToUserAsync(notification);
                    Console.WriteLine($"[BACKEND-CONTROLLER] [Unique] 🟢 Đã gọi xong service gửi thông báo cho UserId = {notification.UserId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[BACKEND-CONTROLLER] [Unique] ❌ Lỗi khi gọi NotificationService cho UserId {notification.UserId}: {ex.Message}");
                }
            }
            // Trường hợp 2: Gửi cho người yêu thích sân (STADIUM) - LOGIC MỚI
            else if ("Stadium".Equals(discount.CodeType, StringComparison.OrdinalIgnoreCase) && discount.StadiumIds != null && discount.StadiumIds.Any())
            {
                Console.WriteLine($"[BACKEND-CONTROLLER] [Stadium Batch] Bắt đầu xử lý batch cho sân: {string.Join(", ", discount.StadiumIds)}");
                var usersAndTheirFavoriteStadiums = new Dictionary<int, List<string>>();

                // (Lặp qua sân, lấy favorites, thêm vào Dictionary - logic cũ)
                foreach (var stadiumId in discount.StadiumIds)
                {
                    string? currentStadiumName = null;
                    try
                    {
                        var stadium = await _stadiumService.GetStadiumByIdAsync(stadiumId);
                        if (stadium != null)
                        {
                            currentStadiumName = stadium.Name;
                            var favorites = await _favoriteStadiumService.GetFavoritesByStadiumIdAsync(stadiumId, accessToken);
                            if (favorites != null && favorites.Any())
                            {
                                foreach (var fav in favorites)
                                {
                                    if (!usersAndTheirFavoriteStadiums.ContainsKey(fav.UserId)) usersAndTheirFavoriteStadiums[fav.UserId] = new List<string>();
                                    if (!usersAndTheirFavoriteStadiums[fav.UserId].Contains(currentStadiumName)) usersAndTheirFavoriteStadiums[fav.UserId].Add(currentStadiumName);
                                }
                            }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine($"[BACKEND-CONTROLLER] [Stadium Batch] ❌ Lỗi xử lý sân {stadiumId}: {ex.Message}"); }
                }

                // === TẠO LIST<NotificationDTO> TỪ DICTIONARY ===
                var notificationsToSendInBatch = new List<CreateNotificationDto>();
                if (usersAndTheirFavoriteStadiums.Any())
                {
                    Console.WriteLine($"[BACKEND-CONTROLLER] [Stadium Batch] === TẠO {usersAndTheirFavoriteStadiums.Count} DTOs cho batch ===");
                    foreach (var kvp in usersAndTheirFavoriteStadiums)
                    {
                        string appliedStadiumsMessage = string.Join(", ", kvp.Value);
                        var notification = new CreateNotificationDto
                        {
                            UserId = kvp.Key, // UserId từ Dictionary key
                            Type = "Discount.New",
                            Title = "Sân bạn yêu thích có mã giảm giá mới!",
                            Message = $"Sân '{appliedStadiumsMessage}' bạn yêu thích có mã giảm giá mới: {discount.Code}.", // Rút gọn message
                            Parameters = JsonSerializer.Serialize(new { discountCode = discount.Code }),
                        };
                        notificationsToSendInBatch.Add(notification);
                        Console.WriteLine($"   - Đã tạo DTO cho UserId: {kvp.Key}");
                    }
                }
                else
                {
                    Console.WriteLine("[BACKEND-CONTROLLER] [Stadium Batch] === KHÔNG CÓ USER NÀO ĐỂ TẠO BATCH ===");
                    return;
                }

                // === GỌI HÀM SendNotificationsBatchAsync MỘT LẦN ===
                if (notificationsToSendInBatch.Any())
                {
                    Console.WriteLine($"[BACKEND-CONTROLLER] [Stadium Batch] 🟡 Chuẩn bị gọi service gửi batch {notificationsToSendInBatch.Count} thông báo...");
                    try
                    {
                        // Gọi hàm batch mới trong NotificationService
                        bool batchSuccess = await _notificationService.SendNotificationsBatchAsync(notificationsToSendInBatch, accessToken);
                        if (batchSuccess) Console.WriteLine($"[BACKEND-CONTROLLER] [Stadium Batch] 🟢 Gọi xong service gửi batch.");
                        else Console.WriteLine($"[BACKEND-CONTROLLER] [Stadium Batch] ⚠️ Service gửi batch trả về false.");
                    }
                    catch (Exception ex) { Console.WriteLine($"[BACKEND-CONTROLLER] [Stadium Batch] ❌ Lỗi khi gọi service batch: {ex.Message}"); }
                }
            }
            else
            {
                Console.WriteLine($"[BACKEND-CONTROLLER] [Notification] Mã giảm giá '{discount.Code}' không thuộc loại 'Unique' hay 'Stadium'.");
            }
        }
    }
}
