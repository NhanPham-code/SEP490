using AutoMapper;
using NotificationAPI.Dto;
using NotificationAPI.Model;
using NotificationAPI.Repository.Interface;
using NotificationAPI.Service.Interface;

namespace NotificationAPI.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<Notification> AddNotificationAsync(CreateNotificationDto createNotificationDto)
        {
            var newNotification = _mapper.Map<Notification>(createNotificationDto);
            newNotification.IsRead = false; // Mặc định là chưa đọc
            newNotification.CreatedAt = DateTime.Now; // Thiết lập thời gian tạo

            var result = await _notificationRepository.AddAsync(newNotification);
            return result;
        }
        public async Task<List<Notification>> AddRangeNotificationsAsync(List<CreateNotificationDto> createNotificationDtos)
        {
            var newNotifications = createNotificationDtos.Select(dto =>
            {
                var notification = _mapper.Map<Notification>(dto);
                notification.IsRead = false; // Mặc định là chưa đọc
                notification.CreatedAt = DateTime.Now; // Thiết lập thời gian tạo
                return notification;
            }).ToList();

            var result = await _notificationRepository.AddRangeAsync(newNotifications);
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
    }
}
