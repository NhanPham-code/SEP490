using DTOs.FavoriteStadiumDTO;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FavoriteStadiumService : IFavoriteStadiumService
    {
        private readonly HttpClient _httpClient;

        // Giả sử GatewayHttpClient đã được cấu hình với BaseAddress của Ocelot Gateway
        public FavoriteStadiumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Helper để thêm token vào header của mỗi request.
        /// </summary>
        private void AddBearerAccessToken(string token)
        {
            // Xóa header cũ (nếu có) để đảm bảo không bị trùng lặp
            _httpClient.DefaultRequestHeaders.Authorization = null;
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<FavoriteDTO> AddFavoriteAsync(CreateFavoriteDTO createFavoriteDTO, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gửi request POST đến Gateway với DTO trong body
            var response = await _httpClient.PostAsJsonAsync("/favoriteStadium", createFavoriteDTO);

            response.EnsureSuccessStatusCode();

            var createdFavorite = await response.Content.ReadFromJsonAsync<FavoriteDTO>();
            if (createdFavorite == null)
            {
                throw new Exception("Failed to deserialize the created favorite from API response.");
            }
            return createdFavorite;
        }

        public async Task<bool> DeleteFavoriteAsync(int favoriteId, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gửi request DELETE đến Gateway
            var response = await _httpClient.DeleteAsync($"/favoriteStadium/{favoriteId}");

            // Trả về true nếu status code là 2xx (ví dụ 204 No Content), false nếu thất bại.
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<FavoriteDTO>> GetMyFavoritesAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Sử dụng route "myFavoriteStadium" đã cấu hình trong Ocelot
            var response = await _httpClient.GetAsync("/myFavoriteStadium");

            // Ném ra exception nếu request không thành công (status code không phải 2xx)
            response.EnsureSuccessStatusCode();

            // Đọc và deserialize JSON từ response body
            var favorites = await response.Content.ReadFromJsonAsync<IEnumerable<FavoriteDTO>>();
            return favorites ?? new List<FavoriteDTO>();
        }

        public async Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gửi request GET đến Gateway với userId và stadiumId dưới dạng query parameters
            var response = await _httpClient.GetAsync($"/favoriteStadium/exists?userId={userId}&stadiumId={stadiumId}");
            return response.IsSuccessStatusCode;
        }

    }
}
