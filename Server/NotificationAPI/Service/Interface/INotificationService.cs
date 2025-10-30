using NotificationAPI.Dto;
using NotificationAPI.Model;

namespace NotificationAPI.Service.Interface
{
    public interface INotificationService
    {
        Task<Notification> AddNotificationAsync(CreateNotificationDto notification);

        Task<List<Notification>> AddRangeNotificationsAsync(List<CreateNotificationDto> notifications);

        Task<Notification?> GetNotificationByIdAsync(int id);

        Task DeleteNotificationAsync(int id);

        Task MarkAllAsReadAsync(int userId);

        Task<int> CountUnreadNotificationsAsync(int userId);

        IQueryable<Notification> GetNotificationsQueryable();
    }
}
