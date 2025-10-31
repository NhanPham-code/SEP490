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
            var response = await _httpClient.GetAsync($"/notifications/myNotification?$filter=UserId eq {userId} or UserId eq 0 &$top={top}&$skip={skip}&$orderby=CreatedAt desc");

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



        private async Task<bool> SendNotificationViaHttpAsync(CreateNotificationDto notification)
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
        public async Task<bool> SendNotificationToUserAsync(CreateNotificationDto notification)
        {
            // === CODE MỚI (PHƯƠNG ÁN 3) ===
            return await SendNotificationViaHttpAsync(notification);

            // === CODE CŨ CỦA BẠN (Đã comment lại) ===
            // HubConnection connection = await ConnectToSignalRAsync();
            // await connection.InvokeAsync("SendNotificationToUser", notification);
            // return true;
        }

        public async Task<bool> SendNotificationToGroupUserAsync(string groupName, List<CreateNotificationDto> notificationDTOs)
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

        public async Task<bool> SendNotificationToAll(CreateNotificationDto notification)
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

        public async Task<bool> SendNotificationsBatchAsync(List<CreateNotificationDto> notifications, string accessToken)
        {
            if (notifications == null || !notifications.Any())
            {
                Console.WriteLine("[NotificationService] SendNotificationsBatchAsync skipped: List is empty or null.");
                return true;
            }
            // Lọc bỏ những notification không hợp lệ (thiếu UserId) trước khi gửi
            var validNotifications = notifications.Where(n => n != null && n.UserId.HasValue && n.UserId > 0).ToList();
            if (!validNotifications.Any())
            {
                Console.WriteLine("[NotificationService] SendNotificationsBatchAsync skipped: No valid notifications with UserId found in the list.");
                return true;
            }

            AddBearerAccessToken(accessToken);
            Console.WriteLine($"[NotificationService] Attempting to send batch of {validNotifications.Count} notifications via Gateway...");
            // Gọi endpoint batch qua Gateway
            var response = await _httpClient.PostAsJsonAsync("/notifications/batch", validNotifications);
            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"[NotificationService] Batch notification request sent successfully to Gateway.");
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[NotificationService] Error sending notifications batch request: {ex.Message} (StatusCode: {ex.StatusCode})");
                try
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[NotificationService] Batch Error Response Content: {errorContent}");
                }
                catch { /* Ignore */ }
                return false;
            }
        }

        // === HÀM GỬI ALL (BROADCAST - MỚI) ===
        public async Task<bool> SendBroadcastNotificationAsync(CreateNotificationDto notification, string accessToken)
        {
            // Kiểm tra đầu vào cơ bản (không cần UserId)
            if (notification == null || string.IsNullOrWhiteSpace(notification.Message))
            {
                Console.WriteLine("[NotificationService] SendBroadcastNotificationAsync skipped: Invalid notification or missing message.");
                return false;
            }
            // Không cần set UserId = null ở đây, vì NotificationAPI sẽ làm việc đó.

            AddBearerAccessToken(accessToken);
            Console.WriteLine($"[NotificationService] Attempting to send broadcast notification via Gateway...");

            // Gọi endpoint broadcast mới (/notifications/all) qua Gateway
            var response = await _httpClient.PostAsJsonAsync("/notifications/all", notification);

            try
            {
                response.EnsureSuccessStatusCode(); // Kiểm tra lỗi trả về từ Gateway/API
                Console.WriteLine($"[NotificationService] Broadcast notification request sent successfully to Gateway.");
                return true;
            }
            catch (HttpRequestException ex)
            {
                // Ghi log lỗi chi tiết
                Console.WriteLine($"[NotificationService] Error sending broadcast notification request: {ex.Message} (StatusCode: {ex.StatusCode})");
                try
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[NotificationService] Broadcast Error Response Content: {errorContent}");
                }
                catch { /* Ignore */ }
                return false; // Trả về false nếu request thất bại
            }
        }
    }
}
