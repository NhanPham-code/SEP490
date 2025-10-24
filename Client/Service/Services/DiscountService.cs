using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs.DiscountDTO;
using DTOs.OData;
using Service.BaseService;
using Service.Interfaces;

namespace Service.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // GET /discounts - For GetAll()
        public async Task<List<ReadDiscountDTO>?> GetAllDiscountsAsync()
        {
            var response = await _httpClient.GetAsync("/discounts");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<List<ReadDiscountDTO>>();
        }

        // GET /discounts/{id}
        public async Task<ReadDiscountDTO?> GetDiscountByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/discounts/{id}");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<ReadDiscountDTO>();
        }

        // GET /discounts/code/{code}
        public async Task<ReadDiscountDTO?> GetDiscountByCodeAsync(string code)
        {
            var response = await _httpClient.GetAsync($"/discounts/code/{code}");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<ReadDiscountDTO>();
        }

        // GET /discounts/stadium/{stadiumId}
        public async Task<List<ReadDiscountDTO>?> GetDiscountsByStadiumIdAsync(int stadiumId)
        {
            var response = await _httpClient.GetAsync($"/discounts/stadium/{stadiumId}");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<List<ReadDiscountDTO>>();
        }

        // POST /discounts
        public async Task<ReadDiscountDTO?> CreateDiscountAsync(string accessToken, CreateDiscountDTO dto)
        {
            AddBearerAccessToken(accessToken);

            var response = await _httpClient.PostAsJsonAsync("/discounts", dto);
            var userId = dto.UserId;
            Console.WriteLine($"------------------------------------------------{userId}");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<ReadDiscountDTO>();
        }

        // PUT /discounts
        public async Task<bool> UpdateDiscountAsync(string accessToken, UpdateDiscountDTO dto)
        {
            AddBearerAccessToken(accessToken);

            // Logging ngày giờ và trạng thái isActive gửi lên
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [CLIENT] UpdateDiscountAsync - Id: {dto.Id}, isActive: {dto.IsActive}");

            var response = await _httpClient.PutAsJsonAsync("/discounts", dto);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Lấy danh sách discount qua OData với lọc, phân trang, count
        /// </summary>
        public async Task<OdataHaveCountResponse<ReadDiscountDTO>?> GetDiscountsByUserAsync(
        string accessToken,
        int? userId = null,
        int page = 1,
        int pageSize = 5,
        string? searchByCode = null,
        int? stadiumId = null,
        bool? isActive = null,
        string? targetUserId = null) // 👈 thêm tham số mới
        {
            AddBearerAccessToken(accessToken);

            var filters = new List<string>();

            if (userId.HasValue)
            {
                filters.Add($"userId eq '{userId.Value}'");
            }

            if (!string.IsNullOrEmpty(searchByCode))
            {
                filters.Add($"contains(tolower(Code), tolower('{searchByCode}'))");
            }

            if (isActive.HasValue)
            {
                filters.Add($"IsActive eq {isActive.Value.ToString().ToLower()}");
            }

            if (stadiumId.HasValue)
            {
                filters.Add($"StadiumIds/any(s: s eq {stadiumId.Value})");
            }

            if (!string.IsNullOrEmpty(targetUserId)) // 👈 thêm điều kiện filter mới
            {
                filters.Add($"TargetUserId eq '{targetUserId}'");
            }

            var query = new List<string>();
            if (filters.Any())
            {
                query.Add($"$filter={string.Join(" and ", filters)}");
            }

            var skip = (page - 1) * pageSize;
            query.Add($"$skip={skip}");
            query.Add($"$top={pageSize}");
            query.Add("$count=true");

            var requestUrl = $"/odata/discounts?{string.Join("&", query)}";

            var response = await _httpClient.GetAsync(requestUrl);
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<OdataHaveCountResponse<ReadDiscountDTO>>();
        }
    }
}
