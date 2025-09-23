using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StadiumAPI.DTOs;

namespace StadiumAPI.Services
{
    public class FirebaseService : IFirebaseService
    {
        private readonly HttpClient _httpClient;
        private readonly string _firebaseUrl = "https://chatbox-993b2-default-rtdb.firebaseio.com";

        public FirebaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddStadiumAsync(ReadStadiumDTO stadium)
        {
            // Khi tạo, isApproved mặc định là false
            var data = new Dictionary<string, object>
            {
                ["id"] = stadium.Id,
                ["lat"] = stadium.Latitude,
                ["lng"] = stadium.Longitude,
                ["name"] = stadium.Name,
                ["isLocked"] = stadium.IsLocked,
                ["isApproved"] = stadium.IsApproved,
            };

            var json = JsonSerializer.Serialize(data);

            var url = $"{_firebaseUrl}/customPlaces/{stadium.Id}.json";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }


        public async Task UpdateStadiumAsync(ReadStadiumDTO stadium)
        {
            // 🔥 Chỉ update các field khác, không đụng vào Id
            var data = new
            {
                lat = stadium.Latitude,
                lng = stadium.Longitude,
                name = stadium.Name,
                isLocked = stadium.IsLocked,
                isApproved = stadium.IsApproved,
            };

            var json = JsonSerializer.Serialize(data);

            var url = $"{_firebaseUrl}/customPlaces/{stadium.Id}.json";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Dùng PATCH thay vì PUT
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = content };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        // Thay đổi method DeleteStadiumAsync trong FirebaseService
        public async Task DeleteStadiumAsync(int stadiumId)
        {
            // Đầu tiên lấy giá trị hiện tại của isLocked
            var getUrl = $"{_firebaseUrl}/customPlaces/{stadiumId}/isLocked.json";
            var getResponse = await _httpClient.GetAsync(getUrl);
            getResponse.EnsureSuccessStatusCode();

            var currentValueJson = await getResponse.Content.ReadAsStringAsync();
            bool currentIsLocked = false; // Mặc định là false nếu không tồn tại

            if (!string.IsNullOrEmpty(currentValueJson) && currentValueJson != "null")
            {
                currentIsLocked = JsonSerializer.Deserialize<bool>(currentValueJson);
            }

            // Toggle giá trị: false -> true, true -> false
            var newIsLocked = !currentIsLocked;

            var data = new
            {
                isLocked = newIsLocked
            };
            var json = JsonSerializer.Serialize(data);
            var url = $"{_firebaseUrl}/customPlaces/{stadiumId}.json";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = content };
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
