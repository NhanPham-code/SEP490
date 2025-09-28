using DTOs.OData;
using DTOs.StadiumEquipmentDTO;
using Service.BaseService;
using Service.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Service.Services
{
    public class StadiumEquipmentService : IStadiumEquipmentService
    {
        private readonly HttpClient _httpClient;

        public StadiumEquipmentService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IEnumerable<StadiumEquipmentResponse>> GetAllAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.GetAsync("stadium-equipment");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[StadiumEquipmentService] GetAllAsync failed: {response.StatusCode}");
                return new List<StadiumEquipmentResponse>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<StadiumEquipmentResponse>>()
                   ?? new List<StadiumEquipmentResponse>();
        }

        public async Task<StadiumEquipmentResponse?> GetByIdAsync(string accessToken, int id)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.GetAsync($"stadium-equipment/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[StadiumEquipmentService] GetByIdAsync failed: {response.StatusCode}");
                return null;
            }
            return await response.Content.ReadFromJsonAsync<StadiumEquipmentResponse>();
        }

        public async Task<StadiumEquipmentResponse?> CreateAsync(CreateStadiumEquipment dto, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            using var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(dto.StadiumId.ToString()), "StadiumId");
            formData.Add(new StringContent(dto.Name), "Name");
            if (!string.IsNullOrEmpty(dto.Description))
                formData.Add(new StringContent(dto.Description), "Description");

            formData.Add(new StringContent(dto.QuantityTotal.ToString()), "QuantityTotal");
            formData.Add(new StringContent(dto.QuantityAvailable.ToString()), "QuantityAvailable");
            if (!string.IsNullOrEmpty(dto.Status))
                formData.Add(new StringContent(dto.Status), "Status");

            if (dto.ImageFile != null)
            {
                var imageContent = new StreamContent(dto.ImageFile.OpenReadStream());
                imageContent.Headers.ContentType = new MediaTypeHeaderValue(dto.ImageFile.ContentType);
                formData.Add(imageContent, "ImageFile", dto.ImageFile.FileName);
            }

            var response = await _httpClient.PostAsync("stadium-equipment", formData);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[StadiumEquipmentService] CreateAsync failed: {response.StatusCode} - {errorMessage}");
                return null;
            }

            return await response.Content.ReadFromJsonAsync<StadiumEquipmentResponse>();
        }

        public async Task<bool> UpdateAsync(string accessToken, int id, UpdateStadiumEquipment dto)
        {
            AddBearerAccessToken(accessToken);

            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(dto.Name), "Name");
            content.Add(new StringContent(dto.Description ?? string.Empty), "Description");
            content.Add(new StringContent(dto.QuantityTotal.ToString()), "QuantityTotal");
            content.Add(new StringContent(dto.QuantityAvailable.ToString()), "QuantityAvailable");
            content.Add(new StringContent(dto.Status ?? string.Empty), "Status");
            content.Add(new StringContent(dto.KeepCurrentImage.ToString().ToLower()), "KeepCurrentImage");

            if (dto.ImageFile != null)
            {
                var fileContent = new StreamContent(dto.ImageFile.OpenReadStream());
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(dto.ImageFile.ContentType);
                content.Add(fileContent, "ImageFile", dto.ImageFile.FileName);
            }

            var response = await _httpClient.PutAsync($"stadium-equipment/{id}", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[StadiumEquipmentService] UpdateAsync failed: {response.StatusCode} - {errorContent}");
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAsync(string accessToken, int id)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.DeleteAsync($"stadium-equipment/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[StadiumEquipmentService] DeleteAsync failed: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<StadiumEquipmentResponse>> GetByStadiumIdAsync(int stadiumId)
        {
            var response = await _httpClient.GetAsync($"odata/stadium-equipments?$filter=stadiumId eq {stadiumId}&$count=true");
            Console.WriteLine($"[StadiumEquipmentService] GET odata/StadiumEquipmentOData?$filter=stadiumId eq {stadiumId} => {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[StadiumEquipmentService] Error content: {errorContent}");
                return new List<StadiumEquipmentResponse>();
            }

            var odataResponse = await response.Content.ReadFromJsonAsync<ODataResponse<StadiumEquipmentResponse>>();
            return odataResponse?.Value ?? new List<StadiumEquipmentResponse>();
        }

        public async Task<(IEnumerable<StadiumEquipmentResponse> data, int totalCount)> GetByStadiumIdPagedAsync(int stadiumId, int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var response = await _httpClient.GetAsync(
                $"odata/stadium-equipments?$filter=stadiumId eq {stadiumId}&$skip={skip}&$top={pageSize}&$count=true&$orderby=createdAt desc"
            );

            Console.WriteLine($"[StadiumEquipmentService] GET with pagination => {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[StadiumEquipmentService] Error content: {errorContent}");
                return (new List<StadiumEquipmentResponse>(), 0);
            }

            var odataResponse = await response.Content.ReadFromJsonAsync<ODataResponse<StadiumEquipmentResponse>>();
            return (odataResponse?.Value ?? new List<StadiumEquipmentResponse>(), odataResponse?.Count ?? 0);
        }
    }
}
