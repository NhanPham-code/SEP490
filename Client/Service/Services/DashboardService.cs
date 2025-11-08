using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<string> GetStadiumManagerDashboardDataAsync(string accessToken)
        {
            // Đính kèm token vào header cho request này
            AddBearerAccessToken(accessToken);

            // Gọi đến Upstream Path của Gateway
            var response = await _httpClient.GetAsync("aggregator/stadiums-kpis");

            // Kiểm tra nếu request không thành công
            response.EnsureSuccessStatusCode();

            // Đọc nội dung response dưới dạng chuỗi JSON
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAdminDashboardDataAsync()
        {
            // Gọi đến Upstream Path của Gateway
            var response = await _httpClient.GetAsync("aggregator/admin-dashboard");

            // Kiểm tra nếu request không thành công
            response.EnsureSuccessStatusCode();

            // Đọc nội dung response dưới dạng chuỗi JSON
            return await response.Content.ReadAsStringAsync();
        }
    }
}
