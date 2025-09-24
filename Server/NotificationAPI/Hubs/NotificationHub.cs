using Microsoft.AspNetCore.SignalR;
using NotificationAPI.Model;
using NotificationAPI.Service.Interface;

namespace NotificationAPI.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly INotificationService _notificationService;

        public NotificationHub(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // Gửi notification tới một user (có thể gọi từ backend khác)
        public async Task SendNotificationToUser(Notification notification)
        {
            // Lưu vào database
            await _notificationService.AddNotificationAsync(notification);

            // Gửi realtime tới client có userId
            await Clients.User(notification.UserId.ToString()).SendAsync("ReceiveNotification", notification);
        }

        // method gửi tới tất cả client đã kết nối
        public async Task SendNotificationToAll(Notification notification)
        {
            // Lưu vào database
            await _notificationService.AddNotificationAsync(notification);

            // Gửi realtime tới tất cả client
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }

        // method gửi đến 1 nhóm client
        public async Task SendNotificationToGroup(string groupName, Notification notification)
        {
            // Lưu vào database
            await _notificationService.AddNotificationAsync(notification);

            // Gửi realtime tới nhóm client
            await Clients.Group(groupName).SendAsync("ReceiveNotification", notification);
        }

        // Đánh dấu tất cả đã đọc
        public async Task MarkAllAsRead(int userId)
        {
            await _notificationService.MarkAllAsReadAsync(userId);
        }
    }
}
