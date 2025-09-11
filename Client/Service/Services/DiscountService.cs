using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs.DiscountDTO;
using Service.BaseService;
using Service.Interfaces;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

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

            if (!response.IsSuccessStatusCode)
            {
                // Return null if the request fails
                return null;
            }

            // Deserialize directly into List<ReadDiscountDTO>
            return await response.Content.ReadFromJsonAsync<List<ReadDiscountDTO>>();
        }

        // GET /discounts/{id} - For GetById()
        public async Task<ReadDiscountDTO?> GetDiscountByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/discounts/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ReadDiscountDTO>();
        }

        // GET /discounts/code/{code} - For GetByCode()
        public async Task<ReadDiscountDTO?> GetDiscountByCodeAsync(string code)
        {

            var response = await _httpClient.GetAsync($"/discounts/code/{code}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ReadDiscountDTO>();
        }

        // GET /discounts/stadium/{stadiumId} - For GetByStadiumId()
        public async Task<List<ReadDiscountDTO>?> GetDiscountsByStadiumIdAsync(int stadiumId)
        {
            var response = await _httpClient.GetAsync($"/discounts/stadium/{stadiumId}");

            if (!response.IsSuccessStatusCode)
            {
                // Return null if the request fails
                return null;
            }

            // Deserialize directly into List<ReadDiscountDTO>
            return await response.Content.ReadFromJsonAsync<List<ReadDiscountDTO>>();
        }

        // POST /discounts - For Create()
        public async Task<ReadDiscountDTO?> CreateDiscountAsync(string accessToken, CreateDiscountDTO dto)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.PostAsJsonAsync("/discounts", dto);

            if (!response.IsSuccessStatusCode)
            {
                // Return null on failure instead of throwing a generic exception
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ReadDiscountDTO>();
        }

        // PUT /discounts - For Update()
        public async Task<bool> UpdateDiscountAsync(string accessToken, UpdateDiscountDTO dto)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.PutAsJsonAsync("/discounts", dto);

            // Return true if the update was successful (204 NoContent)
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Lấy danh sách khuyến mãi của người dùng với các tùy chọn lọc và phân trang.
        /// </summary>
        /// <param name="accessToken">Access token để xác thực.</param>
        /// <param name="userId">ID của người dùng.</param>
        /// <param name="page">Số trang hiện tại (bắt đầu từ 1).</param>
        /// <param name="pageSize">Số lượng mục trên mỗi trang.</param>
        /// <param name="searchByCode">Tìm kiếm theo mã khuyến mãi.</param>
        /// <param name="stadiumId">Lọc theo ID của sân vận động.</param>
        /// <param name="isActive">Lọc theo trạng thái hoạt động.</param>
        /// <returns>Danh sách các khuyến mãi hoặc null nếu có lỗi.</returns>
        public async Task<List<ReadDiscountDTO>?> GetDiscountsByUserAsync(
            string accessToken,
            string userId,
            int page = 1,
            int pageSize = 5,
            string? searchByCode = null,
            int? stadiumId = null,
            bool? isActive = null)
        {
            AddBearerAccessToken(accessToken);

            // Xây dựng các biểu thức lọc OData
            var filterExpressions = new List<string> { $"UserId eq '{userId}'" };

            if (stadiumId.HasValue)
            {
                // API của bạn cần hỗ trợ truy vấn collection 'any'
                filterExpressions.Add($"StadiumIds/any(s: s eq {stadiumId.Value})");
            }

            if (isActive.HasValue)
            {
                filterExpressions.Add($"IsActive eq {isActive.Value.ToString().ToLower()}");
            }

            // Tính toán skip cho phân trang
            var skip = (page - 1) * pageSize;

            // Xây dựng chuỗi truy vấn (query string)
            var query = new List<string> { $"$filter={string.Join(" and ", filterExpressions)}" };
            query.Add($"$skip={skip}");
            query.Add($"$top={pageSize}");
            query.Add("$count=true"); // Yêu cầu API trả về tổng số lượng để phân trang

            if (!string.IsNullOrEmpty(searchByCode))
            {
                // API của bạn cần được cấu hình để $search hoạt động trên trường 'Code'
                query.Add($"$search=\"{searchByCode}\"");
            }

            var queryString = string.Join("&", query);
            var response = await _httpClient.GetAsync($"/discounts?{queryString}");

            if (!response.IsSuccessStatusCode)
            {
                // Xử lý lỗi (ví dụ: log lỗi)
                return null;
            }

            // TODO: Bạn cần một đối tượng để đọc phản hồi có chứa dữ liệu và tổng số lượng
            // Ví dụ: ODataResponse<T> { Value: List<T>, @odata.count: int }
            // Hiện tại, chúng ta chỉ đọc danh sách
            return await response.Content.ReadFromJsonAsync<List<ReadDiscountDTO>>();
        }

    }
}