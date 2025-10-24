using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationAPI.Service.Interface;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using NotificationAPI.Hubs;
using NotificationAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System; // Needed for DateTime

namespace NotificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Yêu cầu xác thực cho controller
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationsController(
            INotificationService notificationService,
            IHubContext<NotificationHub> hubContext)
        {
            _notificationService = notificationService;
            _hubContext = hubContext;
        }

        // --- Tạo đơn lẻ ---
        [HttpPost]
        public async Task<ActionResult> CreateNotification([FromBody] Model.Notification notification)
        {
            // Yêu cầu UserId > 0
            if (notification == null || string.IsNullOrWhiteSpace(notification.Message) || !notification.UserId.HasValue || notification.UserId <= 0)
            {
                return BadRequest(new { message = "Notification object must include a valid UserId (> 0) and Message." });
            }
            notification.CreatedAt = DateTime.Now;

            var createdNotification = await _notificationService.AddNotificationAsync(notification);
            if (createdNotification == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to save notification." });
            }

            try
            {
                await _hubContext.Clients.User(createdNotification.UserId.Value.ToString()).SendAsync("ReceiveNotification", createdNotification);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[NotificationAPI] Error SignalR (single) User {createdNotification.UserId}: {ex.Message}");
            }

            return CreatedAtAction(nameof(GetNotificationById), new { id = createdNotification.Id }, createdNotification);
        }

        // --- Tạo theo nhóm (Batch) ---
        [HttpPost("batch")]
        public async Task<ActionResult> CreateNotificationsBatch([FromBody] List<Model.Notification> notifications)
        {
            if (notifications == null || !notifications.Any()) return BadRequest(new { message = "Notification list is empty." });

            var validNotifications = notifications
                .Where(n => n != null && !string.IsNullOrWhiteSpace(n.Message) && n.UserId.HasValue && n.UserId > 0)
                .Select(n => { if (n.CreatedAt == default) n.CreatedAt = DateTime.Now; return n; })
                .ToList();

            if (!validNotifications.Any()) return BadRequest(new { message = "No valid notifications with UserId > 0 found." });

            var createdNotifications = await _notificationService.AddRangeNotificationsAsync(validNotifications);
            if (createdNotifications == null || !createdNotifications.Any())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to save batch." });
            }


            foreach (var cn in createdNotifications)
            {
                try { await _hubContext.Clients.User(cn.UserId.Value.ToString()).SendAsync("ReceiveNotification", cn); }
                catch (Exception ex) { Console.WriteLine($"[NotificationAPI] Error SignalR (batch) User {cn.UserId}: {ex.Message}"); }
            }

            return Ok(new { message = $"{createdNotifications.Count} user-specific notifications created." });
        }

        // --- GỬI CHO TẤT CẢ ---
        [HttpPost("all")]
        public async Task<ActionResult> CreateAllNotification([FromBody] Model.Notification notification)
        {
            if (notification == null || string.IsNullOrWhiteSpace(notification.Message))
            {
                return BadRequest(new { message = "Notification object must include a Message." });
            }

            // Set UserId = 0 và CreatedAt
            notification.UserId = 0;
            notification.CreatedAt = DateTime.Now;

            // Lưu vào DB
            var createdNotification = await _notificationService.AddNotificationAsync(notification);
            if (createdNotification == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to save 'all' notification." });
            }

            // Gửi SignalR cho TẤT CẢ
            try
            {
                await _hubContext.Clients.All.SendAsync("ReceiveNotification", createdNotification);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[NotificationAPI] Error SignalR ('all') ID {createdNotification.Id}: {ex.Message}");
            }

            return Ok(new { message = $"Notification for all users (ID: {createdNotification.Id}) created." });
        }


        // --- GET Endpoints ---

        // GET: api/Notifications/unread/count
        [HttpGet("unread/count")]
        public async Task<ActionResult<int>> GetUnreadNotificationCount()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId) || userId <= 0)
            {
                return BadRequest(new { message = "Invalid or missing user ID in token." });
            }

            var count = await _notificationService.CountUnreadNotificationsAsync(userId);
            return Ok(count);
        }

        // GET: api/Notifications/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Notification>> GetNotificationById(int id)
        {
            if (id <= 0) return BadRequest(new { message = "Invalid notification ID." });

            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null) return NotFound();

            // Kiểm tra quyền: User có phải là người nhận HOẶC là thông báo 'all' (UserId=0)?
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            bool canAccess = false;
            if (notification.UserId == 0) // Thông báo 'all'
            {
                canAccess = true;
            }
            else if (notification.UserId.HasValue && userIdClaim != null && int.TryParse(userIdClaim.Value, out int currentUserId))
            {
                canAccess = (notification.UserId == currentUserId); // Thông báo cá nhân
            }

            if (!canAccess) return Forbid(); // Không có quyền xem

            return Ok(notification);
        }

        // --- PUT/DELETE Endpoints ---

        // PUT: api/Notifications/markAllAsRead
        [HttpPut("markAllAsRead")]
        public async Task<IActionResult> MarkAllAsRead()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId) || userId <= 0) return BadRequest(new { message = "Invalid or missing user ID in token." });

            await _notificationService.MarkAllAsReadAsync(userId);
            return NoContent();
        }

        // GET: api/Notifications/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Notification>> GetNotificationById(int id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        // POST: api/Notifications
        [HttpPost]
        public async Task<ActionResult> CreateNotification([FromBody] Model.Notification notification)
        {
            var createdNotification = await _notificationService.AddNotificationAsync(notification);
            if (createdNotification.UserId.HasValue && createdNotification.UserId > 0)
            {
                await _hubContext.Clients
                    .User(createdNotification.UserId.ToString()) 
                    .SendAsync("ReceiveNotification", createdNotification);
            }
            else
            {

                await _hubContext.Clients.All
                    .SendAsync("ReceiveNotification", createdNotification);
            }

            return CreatedAtAction(nameof(GetNotificationById), new { id = createdNotification.Id }, createdNotification);
        }

        // PUT: api/Notifications/{id}
        // PUT: api/Notifications/{id} 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotificationIsRead(int id, [FromBody] NotificationReadUpdateDto updateDto) // DTO chỉ chứa IsRead
        {
            if (id <= 0 || updateDto == null) return BadRequest(new { message = "Invalid ID or update data." });

            var existingNotification = await _notificationService.GetNotificationByIdAsync(id);
            if (existingNotification == null) return NotFound();

            if (existingNotification.UserId == 0)
            {
                return Forbid("Cannot update 'IsRead' status for 'all' notifications via this endpoint.");
            }

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int currentUserId) || existingNotification.UserId != currentUserId)
            {
                return Forbid(); 
            }

            existingNotification.IsRead = updateDto.IsRead;
            await _notificationService.UpdateNotificationAsync(existingNotification); // Service/Repo chỉ update IsRead
            return NoContent();
        }

        // DELETE: api/Notifications/{id} 
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> DeleteNotification(int id)
        {
            if (id <= 0) return BadRequest(new { message = "Invalid notification ID." });
            // Thêm kiểm tra quyền xóa nếu cần
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null) return NotFound();

            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }
        public class NotificationReadUpdateDto
        {
            public bool IsRead { get; set; }
        }
    }
}

