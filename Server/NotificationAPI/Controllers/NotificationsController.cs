using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationAPI.Service.Interface;
using System.Security.Claims;

namespace NotificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/Notifications/unread/count/{userId}
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
