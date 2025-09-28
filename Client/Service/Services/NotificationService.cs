using DTOs.NotificationDTO;
using DTOs.OData;
using Microsoft.AspNetCore.SignalR.Client;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
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
            
            var response = await _httpClient.GetAsync($"/notifications/unread-count");
            response.EnsureSuccessStatusCode();
            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

        public async Task MarkAllAsReadAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);

            await _httpClient.PutAsync("/notifications/mark-all-as-read", null);
        }
        public async Task<HubConnection> ConnectToSignalRAsync()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7072/notificationHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(_tokenService.GetAccessTokenFromCookie());
                })
                .WithAutomaticReconnect()
                .Build();

            await connection.StartAsync();
            return connection;
        }

        public async Task<bool> SendNotificationToUserAsync(NotificationDTO notification)
        {

            HubConnection connection = await ConnectToSignalRAsync();
            await connection.InvokeAsync("SendNotificationToUser", notification);

            return true;
        }

        public async Task<bool> SendNotificationToGroupUserAsync(string groupName, List<NotificationDTO> notificationDTOs)
        {
            HubConnection connection = await ConnectToSignalRAsync();
            await connection.InvokeAsync("SendNotificationToGroup", groupName, notificationDTOs);
            return true;
        }

        public async Task<bool> SendNotificationToAll(NotificationDTO notification)
        {
            HubConnection connection = await ConnectToSignalRAsync();
            await connection.InvokeAsync("SendNotificationToAll", notification);
            return true;
        }
    }
}
