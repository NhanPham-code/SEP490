using Microsoft.EntityFrameworkCore;
using NotificationAPI.Data;
using NotificationAPI.Model;
using NotificationAPI.Repository.Interface;

namespace NotificationAPI.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationDbContext _context;

        public NotificationRepository(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task<Notification> AddAsync(Notification notification)
        {
            var result = await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> CountUnreadAsync(int userId)
        {
            var count = await _context.Notifications.CountAsync(n => n.UserId == userId && !n.IsRead);
            return count;
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Notification?> GetByIdAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            return notification;
        }

        public IQueryable<Notification> GetNotificationsQueryable()
        {
            return _context.Notifications.AsQueryable();
        }

        public async Task MarkAllAsReadAsync(int userId)
        {
            var notifications = await _context.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .ToListAsync();
            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notification notification)
        {
            var existingNotification = await _context.Notifications.FindAsync(notification.Id);
            if (existingNotification != null)
            {
                // Cập nhật các trường cần thiết
                existingNotification.IsRead = notification.IsRead;
                await _context.SaveChangesAsync();
            }
        }
    }
}
