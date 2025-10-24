using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationAPI.Service.Interface;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR; // <--- 1. Thêm using này
using NotificationAPI.Hubs;         // <--- 2. Thêm using này

namespace NotificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        // 3. Thêm IHubContext
        private readonly IHubContext<NotificationHub> _hubContext;

        // 4. Inject IHubContext vào constructor
        public NotificationsController(
            INotificationService notificationService,
            IHubContext<NotificationHub> hubContext) // <--- Inject ở đây
        {
            _notificationService = notificationService;
            _hubContext = hubContext; // <--- Gán giá trị
        }

        // GET: api/Notifications/unread/count
        [HttpGet("unread/count")]
        public async Task<ActionResult<int>> GetUnreadNotificationCount()
        {
            // lấy userId từ access token trong header
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId) || userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            if (userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            var count = await _notificationService.CountUnreadNotificationsAsync(userId);
            return Ok(count);
        }

        // PUT: api/Notifications/markAllAsRead
        [HttpPut("markAllAsRead")]
        public async Task<IActionResult> MarkAllAsRead()
        {
            // lấy userId từ access token trong header
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId) || userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

            if (userId <= 0)
            {
                return BadRequest(new { message = "Invalid user ID." });
            }

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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, [FromBody] Model.Notification notification)
        {
            if (id != notification.Id)
            {
                return BadRequest();
            }

            await _notificationService.UpdateNotificationAsync(notification);
            return NoContent();
        }

        // DELETE: api/Notifications/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }
    }
}