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
        private readonly IEmailService _emailService;

        public DiscountController(
            IDiscountService discountService,
            IStadiumService stadiumService,
            ITokenService tokenService,
            IUserService userService,
            IFavoriteStadiumService favoriteStadiumService,
            INotificationService notificationService,
            IEmailService emailService) 
        {
            _discountService = discountService;
            _stadiumService = stadiumService;
            _tokenService = tokenService;
            _userService = userService;
            _favoriteStadiumService = favoriteStadiumService;
            _notificationService = notificationService;
            _emailService = emailService; 
        }

        // Action này CHỈ trả về View rỗng
        public IActionResult DiscountList()
        {
            return View();
        }

        // Action này được JavaScript gọi để LẤY TẤT CẢ DỮ LIỆU discount VỚI PHÂN TRANG
        [HttpGet]
        public async Task<IActionResult> GetDiscountPageData(
        int page = 1,
        int pageSize = 5,
        string? searchByCode = null,
        int? stadiumId = null,
        bool? isActive = null)
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

            // ✅ Dùng hàm mới GetDiscountsAsync
            var discountsResponse = await _discountService.GetDiscountsAsync(
                accessToken,
                userId: userId,
                page: page,
                pageSize: pageSize,
                searchByCode: searchByCode,
                stadiumIds: stadiumId.HasValue ? new List<int> { stadiumId.Value } : null,
                isActive: isActive,
                orderBy: "CreatedAt desc"
            );

            var discounts = discountsResponse?.Value ?? new List<ReadDiscountDTO>();
            var totalCount = discountsResponse?.Count ?? 0;

            // Thu thập TargetUserIds từ danh sách discount
            var targetUserIds = discounts
                .Where(d => !string.IsNullOrEmpty(d.TargetUserId) && int.TryParse(d.TargetUserId, out _))
                .Select(d => int.Parse(d.TargetUserId!))
                .Distinct()
                .ToList();

            var targetUsers = new List<PublicUserProfileDTO>();
            if (targetUserIds.Any())
            {
                targetUsers = await _userService.GetUsersByIdsAsync(targetUserIds, accessToken);
            }

            // Lấy danh sách stadium
            string filter = $"&$filter=CreatedBy eq {userId}";
            var stadiumsJson = await _stadiumService.SearchStadiumAsync(filter);

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
                            stadiums = JsonSerializer.Deserialize<List<ReadStadiumDTO>>(valueElement.GetRawText(), options)
                                ?? new List<ReadStadiumDTO>();
                        }
                    }
                }
                catch (JsonException ex)
                {
                    Debug.WriteLine($"JSON Error parsing stadiums: {ex.Message}");
                }
            }

            return Json(new { discounts, stadiums, targetUsers, count = totalCount });
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
                await SendNotificationAndEmailForNewDiscount(createdDiscount, accessToken);
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
        private async Task SendNotificationAndEmailForNewDiscount(ReadDiscountDTO discount, string accessToken)
        {
            // ==================================================================================
            // TRƯỜNG HỢP 1: MÃ CÁ NHÂN (UNIQUE) - Gửi 1 Noti + 1 Email
            // ==================================================================================
            if ("Unique".Equals(discount.CodeType, StringComparison.OrdinalIgnoreCase) &&
                int.TryParse(discount.TargetUserId, out int targetUserId) && targetUserId > 0)
            {
                // 1. Lấy tên các sân áp dụng
                var uniqueStadiumNames = new List<string>();
                if (discount.StadiumIds != null && discount.StadiumIds.Any())
                {
                    foreach (var stadiumId in discount.StadiumIds)
                    {
                        var stadium = await _stadiumService.GetStadiumByIdAsync(stadiumId);
                        if (stadium != null) uniqueStadiumNames.Add(stadium.Name);
                    }
                }
                string stadiumText = uniqueStadiumNames.Any() ? string.Join(", ", uniqueStadiumNames) : "các sân được chọn";

                // 2. Gửi Notification (Logic cũ)
                var notification = new CreateNotificationDto
                {
                    UserId = targetUserId,
                    Type = "Discount.New",
                    Title = "Bạn có mã giảm giá cá nhân!",
                    Message = $"Bạn nhận được mã giảm giá: {discount.Code}, áp dụng cho: '{stadiumText}'.",
                    Parameters = JsonSerializer.Serialize(new { discountCode = discount.Code }),
                };
                await _notificationService.SendNotificationToUserAsync(notification);

                // 3. Gửi Email (NEW)
                try
                {
                    // Lấy thông tin user để lấy Email
                    var user = await _userService.GetOtherUserByIdAsync(targetUserId); // Dùng hàm lấy 1 user cho nhanh
                    if (user != null && !string.IsNullOrEmpty(user.Email))
                    {
                        string subject = $"[Sportivey] Mã giảm giá riêng cho bạn: {discount.Code}";
                        string msgBody = $@"
                    <p>Xin chào <strong>{user.FullName}</strong>,</p>
                    <p>Chúc mừng! Bạn vừa nhận được một mã giảm giá đặc biệt từ Sportivey.</p>
                    <div style='background: #eef2ff; padding: 15px; border-radius: 8px; border: 1px dashed #6366f1; margin: 15px 0;'>
                        <h2 style='color: #4f46e5; margin: 0;'>{discount.Code}</h2>
                        <p><strong>Giảm:</strong> {discount.PercentValue}% (Tối đa {discount.MaxDiscountAmount}đ, áp dụng cho đơn từ {discount.MinOrderAmount}đ)</p>
                        <p><strong>Áp dụng tại:</strong> {stadiumText}</p>
                        <p><strong>Hạn dùng:</strong> {discount.EndDate:dd/MM/yyyy}</p>
                    </div>
                    <p>Hãy nhanh tay sử dụng trước khi hết hạn nhé!</p>
                ";
                        // Link trỏ về trang chủ hoặc trang đặt sân
                        string actionLink = "https://localhost:7128/";
                        await _emailService.SendEmailAsync(user.Email, subject, msgBody, actionLink, "Đặt Sân Ngay");
                        Console.WriteLine($"[Email] Đã gửi mã Unique cho {user.Email}");
                    }
                }
                catch (Exception ex) { Console.WriteLine($"[EmailError] Lỗi gửi mail Unique: {ex.Message}"); }
            }

            // ==================================================================================
            // TRƯỜNG HỢP 2: MÃ THEO SÂN (STADIUM) - Gửi Batch Noti + Batch Email
            // ==================================================================================
            else if ("Stadium".Equals(discount.CodeType, StringComparison.OrdinalIgnoreCase) &&
                     discount.StadiumIds != null && discount.StadiumIds.Any())
            {
                Console.WriteLine($"[Batch] Bắt đầu xử lý batch cho sân: {string.Join(", ", discount.StadiumIds)}");

                // Dictionary: UserId -> List<Tên Sân>
                var usersAndTheirFavoriteStadiums = new Dictionary<int, List<string>>();

                // 1. Thu thập User ID từ danh sách yêu thích của từng sân
                foreach (var stadiumId in discount.StadiumIds)
                {
                    try
                    {
                        var stadium = await _stadiumService.GetStadiumByIdAsync(stadiumId);
                        if (stadium != null)
                        {
                            var favorites = await _favoriteStadiumService.GetFavoritesByStadiumIdAsync(stadiumId, accessToken);
                            if (favorites != null && favorites.Any())
                            {
                                foreach (var fav in favorites)
                                {
                                    if (!usersAndTheirFavoriteStadiums.ContainsKey(fav.UserId))
                                        usersAndTheirFavoriteStadiums[fav.UserId] = new List<string>();

                                    if (!usersAndTheirFavoriteStadiums[fav.UserId].Contains(stadium.Name))
                                        usersAndTheirFavoriteStadiums[fav.UserId].Add(stadium.Name);
                                }
                            }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine($"[BatchError] Lỗi sân {stadiumId}: {ex.Message}"); }
                }

                if (!usersAndTheirFavoriteStadiums.Any()) return;

                // 2. Gửi Notification Batch (Logic cũ)
                var notificationsToSendInBatch = new List<CreateNotificationDto>();
                foreach (var kvp in usersAndTheirFavoriteStadiums)
                {
                    string stadiumNames = string.Join(", ", kvp.Value);
                    notificationsToSendInBatch.Add(new CreateNotificationDto
                    {
                        UserId = kvp.Key,
                        Type = "Discount.New",
                        Title = "Sân bạn yêu thích có ưu đãi mới!",
                        Message = $"Sân '{stadiumNames}' tung mã giảm giá: {discount.Code}. Đặt ngay kẻo lỡ!",
                        Parameters = JsonSerializer.Serialize(new { discountCode = discount.Code }),
                    });
                }
                await _notificationService.SendNotificationsBatchAsync(notificationsToSendInBatch, accessToken);


                // 3. Gửi Email 
                try
                {
                    // Lấy danh sách UserId cần gửi mail
                    var userIdsToSendEmail = usersAndTheirFavoriteStadiums.Keys.ToList();

                    // Gọi UserService lấy thông tin chi tiết (Email, Name) của danh sách ID này
                    var userProfiles = await _userService.GetUsersByIdsAsync(userIdsToSendEmail, accessToken);

                    if (userProfiles != null && userProfiles.Any())
                    {
                        foreach (var userProfile in userProfiles)
                        {
                            if (string.IsNullOrEmpty(userProfile.Email)) continue;

                            // Lấy lại danh sách sân yêu thích của user này để chèn vào mail cho cá nhân hóa
                            var favStadiums = usersAndTheirFavoriteStadiums.ContainsKey(userProfile.UserId)
                                              ? string.Join(", ", usersAndTheirFavoriteStadiums[userProfile.UserId])
                                              : "các sân bạn quan tâm";

                            string subject = $"[Sportivey] Ưu đãi mới từ sân {favStadiums}: {discount.Code}";
                            string msgBody = $@"
                        <p>Xin chào <strong>{userProfile.FullName}</strong>,</p>
                        <p>Sân vận động bạn yêu thích (<strong>{favStadiums}</strong>) vừa tung ra mã giảm giá mới!</p>
                        
                        <div style='background: #ecfdf5; padding: 15px; border-radius: 8px; border: 1px dashed #10b981; margin: 15px 0;'>
                            <h2 style='color: #059669; margin: 0;'>{discount.Code}</h2>
                            <p><strong>Giảm:</strong> {discount.PercentValue}% (Tối đa {discount.MaxDiscountAmount}đ, áp dụng cho đơn từ {discount.MinOrderAmount}đ)</p>
                            <p><strong>Áp dụng tại:</strong> {favStadiums}</p>
                            <p><strong>Hạn dùng:</strong> {discount.EndDate:dd/MM/yyyy}</p>
                        </div>
                        <p>Số lượng có hạn, hãy đặt sân ngay bây giờ!</p>
                    ";

                            // Gửi mail (Lưu ý: Gửi trong vòng lặp có thể chậm nếu list user quá lớn. 
                            // Tốt nhất nên dùng Hangfire/BackgroundJob, nhưng ở đây gửi trực tiếp thì chấp nhận await từng cái hoặc Task.WhenAll)
                            await _emailService.SendEmailAsync(userProfile.Email, subject, msgBody, "https://localhost:7128/", "Săn Deal Ngay");
                            Console.WriteLine($"[EmailBatch] Đã gửi cho {userProfile.Email}");
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine($"[EmailBatchError] Lỗi gửi mail hàng loạt: {ex.Message}"); }
            }
        }
    }
}
