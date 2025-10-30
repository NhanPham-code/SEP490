using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace NotificationAPI.Hubs 
{
    /// <summary>
    /// Class này "dạy" cho SignalR cách lấy UserId từ query string của URL.
    /// </summary>
    public class NameUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            // Lấy giá trị của tham số "userId" từ URL mà client đã kết nối
            // Ví dụ: https://.../notificationHub?userId=2 -> sẽ trả về "2"
            return connection.GetHttpContext()?.Request.Query["userId"];
        }

        /*public string? GetUserId(HubConnectionContext connection)
        {
            // Tìm claim có loại là NameIdentifier trong token của user đã được xác thực.
            // Đây là cách làm đúng chuẩn, bảo mật và nhất quán với [Authorize].
            return connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }*/
    }
}