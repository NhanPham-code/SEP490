using FeeAPI.DTOs;
using FeeAPI.Service.Interface;
using Newtonsoft.Json;

namespace FeeAPI.Service
{
    public class StadiumService : IStadiumService
    {
        private readonly HttpClient _httpClient;
        private readonly string _stadiumApiBaseUrl = "https://localhost:7280"; // URL của StadiumAPI

        public StadiumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OdataHaveCountResponse<ReadStadiumDTO>>> GetReadStadiumDTOsAsync()
        {
            try
            {
                // Gọi đến OData endpoint (thêm $count=true để lấy tổng số)
                // IsLocked eq false 
                // IsApproved eq true
                string filterQuery = "IsLocked eq false and IsApproved eq true";

                string requestUrl = $"{_stadiumApiBaseUrl}/odata/OdataStadium?$count=true&$filter={filterQuery}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Parse JSON -> OdataHaveCountResponse<ReadStadiumDTO>
                var odataResponse = JsonConvert.DeserializeObject<OdataHaveCountResponse<ReadStadiumDTO>>(jsonResponse);

                // Trả về dưới dạng IEnumerable (đặt vào list để phù hợp với interface)
                return new List<OdataHaveCountResponse<ReadStadiumDTO>> { odataResponse };
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Lỗi khi gọi StadiumAPI: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Lỗi parse JSON từ StadiumAPI: {ex.Message}", ex);
            }
        }
    }
}
