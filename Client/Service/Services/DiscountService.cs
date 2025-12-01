using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs.DiscountDTO;
using DTOs.OData;
using Newtonsoft.Json;
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
/// Hàm tổng hợp để query discounts với nhiều filter options
/// </summary>
public async Task<OdataHaveCountResponse<ReadDiscountDTO>?> GetDiscountsAsync(
    string accessToken,
    int? userId = null,
    int page = 1,
    int pageSize = 5,
    string? searchByCode = null,
    List<int>? stadiumIds = null,
    bool? isActive = null,
    string? targetUserId = null,
    bool? isPersonalDiscount = null,
    bool filterExpired = false,
    string? orderBy = null)
    {
        AddBearerAccessToken(accessToken);

        var filters = new List<string>();

        // Filter theo UserId (người tạo discount)
        if (userId.HasValue)
        {
            filters.Add($"UserId eq {userId.Value}");
        }

        // Filter theo mã code (search)
        if (!string.IsNullOrEmpty(searchByCode))
        {
            filters.Add($"contains(tolower(Code), tolower('{searchByCode}'))");
        }

        // Filter theo trạng thái active
        if (isActive.HasValue)
        {
            filters.Add($"IsActive eq {isActive.Value.ToString().ToLower()}");
        }

        // Filter theo stadium IDs
        if (stadiumIds != null && stadiumIds.Any())
        {
            if (stadiumIds.Count == 1)
            {
                // 1 stadium: query đơn giản hơn
                filters.Add($"StadiumIds/any(s: s eq {stadiumIds[0]})");
            }
            else
            {
                // Nhiều stadiums
                var stadiumConditions = string.Join(" or ", stadiumIds.Select(id => $"s eq {id}"));
                filters.Add($"StadiumIds/any(s: {stadiumConditions})");
            }
        }

        // Filter theo TargetUserId cụ thể
        if (!string.IsNullOrEmpty(targetUserId))
        {
            filters.Add($"TargetUserId eq '{targetUserId}'");
        }
        // Filter theo loại discount (personal vs stadium)
        else if (isPersonalDiscount.HasValue)
        {
            filters.Add(isPersonalDiscount.Value
                ? "TargetUserId ne null"   // Mã cá nhân
                : "TargetUserId eq null"); // Mã sân
        }

        // Filter chưa hết hạn
        if (filterExpired)
        {
            filters.Add($"EndDate ge {DateTime.UtcNow:yyyy-MM-ddTHH:mm:ssZ}");
        }

        // Build query
        var query = new List<string>();

        if (filters.Any())
        {
            query.Add($"$filter={string.Join(" and ", filters)}");
        }

        if (!string.IsNullOrEmpty(orderBy))
        {
            query.Add($"$orderby={orderBy}");
        }

        query.Add($"$skip={(page - 1) * pageSize}");
        query.Add($"$top={pageSize}");
        query.Add("$count=true");

        var requestUrl = $"/odata/discounts?{string.Join("&", query)}";

        Console.WriteLine($"[GetDiscountsAsync] URL: {requestUrl}");

        var response = await _httpClient.GetAsync(requestUrl);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"[GetDiscountsAsync] Error: {await response.Content.ReadAsStringAsync()}");
            return null;
        }

        var jsonString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OdataHaveCountResponse<ReadDiscountDTO>>(jsonString);
    }


}



}
