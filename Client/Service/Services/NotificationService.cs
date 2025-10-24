using DTOs.NotificationDTO;
using DTOs.OData;
using Microsoft.AspNetCore.SignalR.Client;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;

        public NotificationService(GatewayHttpClient gateway, ITokenService tokenService)
        {
            _httpClient = gateway.Client;
            _tokenService = tokenService;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IEnumerable<NotificationDTO>> GetNotificationsByUserIdAsync(int userId, int top, int skip)
        {
            var response = await _httpClient.GetAsync($"/notifications/myNotification?$filter=UserId eq {userId}&$top={top}&$skip={skip}&$orderby=CreatedAt desc");

            response.EnsureSuccessStatusCode();
            var odataResponse = await response.Content.ReadFromJsonAsync<ODataResponse<NotificationDTO>>();
            return odataResponse.Value;
        }

        public async Task<int> GetUnreadNotificationCountAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Đảm bảo đường dẫn này khớp với API Gateway và NotificationsController
            var response = await _httpClient.GetAsync($"/notifications/unread-count");
            response.EnsureSuccessStatusCode();
            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

        public async Task MarkAllAsReadAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Đảm bảo đường dẫn này khớp với API Gateway và NotificationsController
            await _httpClient.PutAsync("/notifications/mark-all-as-read", null);
        }

        // Hàm này giữ nguyên, nó dùng cho client (UI) kết nối để LẮNG NGHE (nếu cần)
        public async Task<HubConnection> ConnectToSignalRAsync()
        {
            var connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:7072/notificationHub", options =>
                    {
                        options.AccessTokenProvider = () => Task.FromResult(_tokenService.GetAccessTokenFromCookie());
                    })
                    .WithAutomaticReconnect()
                    .Build();

            // await connection.StartAsync(); // Không nên start ở đây, hàm này chỉ để build connection
            return connection;
        }



        private async Task<bool> SendNotificationViaHttpAsync(NotificationDTO notification)
        {
            try
            {
                var token = _tokenService.GetAccessTokenFromCookie();
                if (string.IsNullOrEmpty(token))
                {
                    Debug.WriteLine("[NotificationService] Lỗi: Không tìm thấy Access Token để gửi thông báo.");
                    return false;
                }

                AddBearerAccessToken(token);

                // Dùng HTTP POST để gọi đến /api/Notifications của NotificationAPI (qua Gateway)
                // Đây chính là endpoint chúng ta đã sửa ở bước 1 (bên NotificationAPI)
                var response = await _httpClient.PostAsJsonAsync("/notifications", notification);

                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[NotificationService] Lỗi khi gửi thông báo qua HTTP: {ex.Message}");
                return false;
            }
        }

        /**
         * Hàm này (và SendNotificationToAll) bây giờ chỉ là một trình bao (wrapper)
         * gọi đến SendNotificationViaHttpAsync.
         * Logic phân biệt "gửi cho 1 người" hay "gửi cho tất cả" 
         * đã nằm ở NotificationAPI (dựa trên notification.UserId có null hay không).
         */
        public async Task<bool> SendNotificationToUserAsync(NotificationDTO notification)
        {
            // === CODE MỚI (PHƯƠNG ÁN 3) ===
            return await SendNotificationViaHttpAsync(notification);

            // === CODE CŨ CỦA BẠN (Đã comment lại) ===
            // HubConnection connection = await ConnectToSignalRAsync();
            // await connection.InvokeAsync("SendNotificationToUser", notification);
            // return true;
        }

        public async Task<bool> SendNotificationToGroupUserAsync(string groupName, List<NotificationDTO> notificationDTOs)
        {
            // === CODE MỚI ===

            // TODO: Endpoint POST /notifications hiện tại chỉ nhận 1 notification,
            // không hỗ trợ gửi theo group hoặc gửi hàng loạt (batch).
            // Nếu cần gửi cho group, bạn có 2 cách:
            // 1. (Khuyên dùng) Sửa logic ở DiscountController: thay vì gọi hàm này,
            //    hãy lặp qua danh sách user trong group và gọi SendNotificationToUserAsync() cho mỗi người.
            // 2. Sửa NotificationAPI: tạo endpoint mới (ví dụ: POST /notifications/batch)
            //    để nhận List<Notification> hoặc { groupName, notification }.

            // Tạm thời, chúng ta sẽ lặp và gửi từng cái một
            bool allSucceeded = true;
            foreach (var notification in notificationDTOs)
            {
                var result = await SendNotificationViaHttpAsync(notification);
                if (!result) allSucceeded = false;
            }
            return allSucceeded;


            // === CODE CŨ  ===
            // HubConnection connection = await ConnectToSignalRAsync();
            // await connection.InvokeAsync("SendNotificationToGroup", groupName, notificationDTOs);
            // return true;
        }

        public async Task<bool> SendNotificationToAll(NotificationDTO notification)
        {
            // === CODE MỚI ===
            // Đặt UserId = null để NotificationAPI biết là gửi cho ALL
            notification.UserId = null;
            return await SendNotificationViaHttpAsync(notification);

            // === CODE CŨ ===
            // HubConnection connection = await ConnectToSignalRAsync();
            // await connection.InvokeAsync("SendNotificationToAll", notification);
            // return true;
        }
    }
}
