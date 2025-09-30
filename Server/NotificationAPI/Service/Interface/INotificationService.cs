using NotificationAPI.Model;

namespace NotificationAPI.Service.Interface
{
    public interface INotificationService
    {
        Task<Notification> AddNotificationAsync(Notification notification);
        Task<List<Notification>> AddRangeNotificationsAsync(List<Notification> notifications);
        Task<Notification?> GetNotificationByIdAsync(int id);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(int id);
        Task MarkAllAsReadAsync(int userId);
        Task<int> CountUnreadNotificationsAsync(int userId);
        IQueryable<Notification> GetNotificationsQueryable();
    }
}
