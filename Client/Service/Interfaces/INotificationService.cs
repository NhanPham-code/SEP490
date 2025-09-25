using DTOs.NotificationDTO;
using DTOs.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDTO>> GetNotificationsByUserIdAsync(int userId, int top, int skip);
        Task<int> GetUnreadNotificationCountAsync(string accessToken);
        Task MarkAllAsReadAsync(string accessToken);
    }
}
