using DTOs.NotificationDTO;
using DTOs.OData;
using Microsoft.AspNetCore.SignalR.Client;
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
        Task<HubConnection> ConnectToSignalRAsync();
        Task<bool> SendNotificationToUserAsync(CreateNotificationDto notificationDTO);
        Task<bool> SendNotificationToGroupUserAsync(string groupName, List<CreateNotificationDto> notificationDTOs);
        Task<bool> SendNotificationToAll(CreateNotificationDto notificationDTO);
        Task<bool> SendNotificationsBatchAsync(List<CreateNotificationDto> notifications, string accessToken);
    }
}
