using NotificationAPI.Model;

namespace NotificationAPI.Repository.Interface
{
    public interface INotificationRepository
    {
        // Thêm notification mới
        Task<Notification> AddAsync(Notification notification);

        // Lấy notification theo Id
        Task<Notification?> GetByIdAsync(int id);

        // Đánh dấu đã đọc (hoặc cập nhật notification)
        Task UpdateAsync(Notification notification);

        // Xoá notification
        Task DeleteAsync(int id);

        // Đánh dấu tất cả là đã đọc cho 1 user
        Task MarkAllAsReadAsync(int userId);

        // Đếm số notification chưa đọc của một user
        Task<int> CountUnreadAsync(int userId);

        // Odata
        IQueryable<Notification> GetNotificationsQueryable();
    }
}
