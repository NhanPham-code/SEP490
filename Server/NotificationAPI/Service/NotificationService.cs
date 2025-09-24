using NotificationAPI.Model;
using NotificationAPI.Repository.Interface;
using NotificationAPI.Service.Interface;

namespace NotificationAPI.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Notification> AddNotificationAsync(Notification notification)
        {
            var result = await _notificationRepository.AddAsync(notification);
            return result;
        }

        public async Task<int> CountUnreadNotificationsAsync(int userId)
        {
            var count = await _notificationRepository.CountUnreadAsync(userId);
            return count;
        }

        public async Task DeleteNotificationAsync(int id)
        {
            await _notificationRepository.DeleteAsync(id);
        }

        public async Task<Notification?> GetNotificationByIdAsync(int id)
        {
            var notification = await  _notificationRepository.GetByIdAsync(id);
            return notification;
        }

        public IQueryable<Notification> GetNotificationsQueryable()
        {
            return _notificationRepository.GetNotificationsQueryable();
        }

        public async Task MarkAllAsReadAsync(int userId)
        {
           await _notificationRepository.MarkAllAsReadAsync(userId);
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            await _notificationRepository.UpdateAsync(notification);
        }
    }
}
