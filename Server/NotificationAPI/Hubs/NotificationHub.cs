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

        public override Task OnConnectedAsync()
        {
            // Context.UserIdentifier là UserId mà IUserIdProvider đã lấy từ token
            var userId = Context.UserIdentifier;

            if (string.IsNullOrEmpty(userId))
            {
                Console.WriteLine($"[NotificationHub] CRITICAL_ERROR: A client connected, but UserId is NULL or EMPTY. ConnectionId: {Context.ConnectionId}");
            }
            else
            {
                Console.WriteLine($"[NotificationHub] SUCCESS: Client connected with UserId: {userId}. ConnectionId: {Context.ConnectionId}");
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.UserIdentifier;
            Console.WriteLine($"[NotificationHub] INFO: Client disconnected. UserId: {userId}, ConnectionId: {Context.ConnectionId}");
            return base.OnDisconnectedAsync(exception);
        }

        // Gửi notification tới một user (có thể gọi từ backend khác)
        public async Task SendNotificationToUser(Notification notification)
        {
            // Gửi realtime tới client có userId
            await Clients.User(notification.UserId.ToString()).SendAsync("ReceiveNotification", notification);
        }

        // method gửi tới tất cả client đã kết nối
        public async Task SendNotificationToAll(Notification notification)
        {

            // Gửi realtime tới tất cả client
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }
        // method tham gia nhóm (group) theo tên nhóm 
        public async Task<bool> RegisterGroups(List<string> groupName)
        {
            foreach (var group in groupName)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, group);

            }

            return true; // hoặc kiểm tra điều kiện rồi trả về true/false
        }

        // method gửi đến 1 nhóm client
        public async Task SendNotificationToGroup(string groupName, List<Notification> notification)
        {
            // Gửi realtime tới nhóm client
            await Clients.Group(groupName).SendAsync("ReceiveNotification", notification.FirstOrDefault());
        }

        // Đánh dấu tất cả đã đọc
        public async Task MarkAllAsRead(int userId)
        {
            await _notificationService.MarkAllAsReadAsync(userId);
        }
    }
}
