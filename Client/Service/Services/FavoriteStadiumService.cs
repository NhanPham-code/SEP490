using DTOs.FavoriteStadiumDTO;
using DTOs.OData;
using DTOs.StadiumDTO;
using Newtonsoft.Json;
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
        private readonly IStadiumService _stadiumService;

        // Giả sử GatewayHttpClient đã được cấu hình với BaseAddress của Ocelot Gateway
        public FavoriteStadiumService(GatewayHttpClient httpClient, IStadiumService stadiumService)
        {
            _httpClient = httpClient.Client;
            _stadiumService = stadiumService;
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

        public async Task<bool> AddFavoriteAsync(CreateFavoriteDTO createFavoriteDTO, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gửi request POST đến Gateway với DTO trong body
            var response = await _httpClient.PostAsJsonAsync("/favoriteStadium", createFavoriteDTO);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteFavoriteAsync(int userId, int stadiumId, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gửi request DELETE đến Gateway
            var response = await _httpClient.DeleteAsync($"/favoriteStadium/{userId}/{stadiumId}");

            // Trả về true nếu status code là 2xx (ví dụ 204 No Content), false nếu thất bại
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ReadFavoriteDTO>> GetMyFavoritesAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Sử dụng route "myFavoriteStadium" đã cấu hình trong Ocelot
            var response = await _httpClient.GetAsync("/myFavoriteStadium");

            // Ném ra exception nếu request không thành công (status code không phải 2xx)
            response.EnsureSuccessStatusCode();

            // Đọc và deserialize JSON từ response body
            var favorites = await response.Content.ReadFromJsonAsync<IEnumerable<ReadFavoriteDTO>>();
            return favorites ?? new List<ReadFavoriteDTO>();
        }

        public async Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // Gửi request GET đến Gateway với userId và stadiumId dưới dạng query parameters
            var response = await _httpClient.GetAsync($"/favoriteStadium/exists?userId={userId}&stadiumId={stadiumId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<string> GetMyFavoritesForUIAsync(string accessToken)
        {
            // Chuyển tiếp việc gọi API sang phương thức GetMyFavoritesAsync
            try
            {
                // 1. Lấy danh sách ID sân yêu thích từ DB/API
                var favorites = await GetMyFavoritesAsync(accessToken);
                var stadiumIds = favorites.Select(f => f.StadiumId).Distinct().ToList();

                if (!stadiumIds.Any())
                {
                    var emptyResponse = new { value = new List<FavoriteStadiumViewModel>(), count = 0 };
                    return JsonConvert.SerializeObject(emptyResponse);
                }

                // 2. Lấy thông tin chi tiết các sân từ StadiumService
                var stadiumsResponse = await _stadiumService.GetAllStadiumByListId(stadiumIds);

                // 3. Chuyển đổi ReadStadiumDTO thành FavoriteStadiumViewModel
                //    Sử dụng AutoMapper sẽ giúp bước này gọn hơn, nhưng làm thủ công cũng không sao.
                var favoriteStadiums = stadiumsResponse.Value.Select(stadium => new FavoriteStadiumViewModel
                {
                    // Sao chép các thuộc tính từ ReadStadiumDTO
                    Id = stadium.Id,
                    Name = stadium.Name,
                    Address = stadium.Address,
                    OpenTime = stadium.OpenTime,
                    CloseTime = stadium.CloseTime,
                    Courts = stadium.Courts,
                    StadiumImages = stadium.StadiumImages,
                    // IsFavorite sẽ mặc định là true
                }).ToList();

                // 4. Tạo đối tượng trả về cuối cùng và serialize thành JSON
                var finalResponse = new
                {
                    value = favoriteStadiums
                };

                return JsonConvert.SerializeObject(finalResponse);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (sử dụng một logger thực tế)
                Console.WriteLine($"Error in GetMyFavoritesForUIAsync: {ex.Message}");
                throw; // Ném lại exception để controller xử lý
            }
        }
    }
}
