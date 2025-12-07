using DTOs.OData;
using FeedbackAPI.DTOs;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly HttpClient _httpClient;

        public FeedbackService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IEnumerable<FeedbackResponse>> GetAllAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.GetAsync("feedback");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[FeedbackService] GetAllAsync failed: {response.StatusCode}");
                return new List<FeedbackResponse>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<FeedbackResponse>>()
                   ?? new List<FeedbackResponse>();
        }

        public async Task<FeedbackResponse?> GetByIdAsync(string accessToken, int id)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.GetAsync($"feedback/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[FeedbackService] GetByIdAsync failed: {response.StatusCode}");
                return null;
            }
            return await response.Content.ReadFromJsonAsync<FeedbackResponse>();
        }

        public async Task<FeedbackResponse?> CreateAsync(CreateFeedback dto, string accessToken)
        {
            try
            {
                AddBearerAccessToken(accessToken);

                // Luôn dùng form data (để handle cả có và không có image)
                using var formData = new MultipartFormDataContent();

                formData.Add(new StringContent(dto.UserId.ToString()), "UserId");
                formData.Add(new StringContent(dto.StadiumId.ToString()), "StadiumId");
                formData.Add(new StringContent(dto.Rating.ToString()), "Rating");

                if (!string.IsNullOrEmpty(dto.Comment))
                {
                    formData.Add(new StringContent(dto.Comment), "Comment");
                }

                if (dto.Image != null)
                {
                    var imageContent = new StreamContent(dto.Image.OpenReadStream());
                    imageContent.Headers.ContentType = new MediaTypeHeaderValue(dto.Image.ContentType);
                    formData.Add(imageContent, "Image", dto.Image.FileName);
                }

                var response = await _httpClient.PostAsync("feedback", formData);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[FeedbackService] CreateAsync failed: {response.StatusCode} - {errorMessage}");
                    throw new Exception($"API CreateFeedback failed: {errorMessage}");
                }

                return await response.Content.ReadFromJsonAsync<FeedbackResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FeedbackService] Exception: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> UpdateAsync(string accessToken, int id, UpdateFeedback dto)
        {
            try
            {
                Console.WriteLine($"[FeedbackService] UpdateAsync called - ID: {id}");
                Console.WriteLine($"[FeedbackService] DTO Rating: {dto.Rating}");
                Console.WriteLine($"[FeedbackService] DTO Comment: '{dto.Comment}'");
                Console.WriteLine($"[FeedbackService] DTO Image: {(dto.Image != null ? $"{dto.Image.FileName} ({dto.Image.Length} bytes)" : "null")}");

                AddBearerAccessToken(accessToken);

                // ✅ Sử dụng MultipartFormDataContent thay vì PutAsJsonAsync
                using var content = new MultipartFormDataContent();

                // Add rating
                content.Add(new StringContent(dto.Rating.ToString()), "Rating");
                Console.WriteLine($"[FeedbackService] Added Rating: {dto.Rating}");

                // Add comment (có thể null hoặc empty)
                content.Add(new StringContent(dto.Comment ?? string.Empty), "Comment");
                Console.WriteLine($"[FeedbackService] Added Comment: '{dto.Comment}'");

                // Add image file nếu có
                if (dto.Image != null && dto.Image.Length > 0)
                {
                    var fileContent = new StreamContent(dto.Image.OpenReadStream());
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(dto.Image.ContentType);
                    content.Add(fileContent, "Image", dto.Image.FileName);
                    Console.WriteLine($"[FeedbackService] Added Image: {dto.Image.FileName}");
                }
                else
                {
                    Console.WriteLine("[FeedbackService] No image to upload");
                }

                Console.WriteLine($"[FeedbackService] Sending PUT request to feedback/{id}");

                var response = await _httpClient.PutAsync($"feedback/{id}", content);

                Console.WriteLine($"[FeedbackService] Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[FeedbackService] UpdateAsync failed: {response.StatusCode}");
                    Console.WriteLine($"[FeedbackService] Error response: {errorContent}");
                    return false;
                }

                Console.WriteLine("[FeedbackService] UpdateAsync successful");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FeedbackService] UpdateAsync exception: {ex.Message}");
                Console.WriteLine($"[FeedbackService] Stack trace: {ex.StackTrace}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string accessToken, int id)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.DeleteAsync($"feedback/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[FeedbackService] DeleteAsync failed: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<FeedbackResponse>> GetByStadiumIdAsync(int stadiumId)
        {
            // Use OData endpoint with $filter query
            var response = await _httpClient.GetAsync($"odata/FeedbackOData?$filter=stadiumId eq {stadiumId}&$count=true");
            Console.WriteLine($"[FeedbackService] GET odata/FeedbackOData?$filter=stadiumId eq {stadiumId} => {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[FeedbackService] Error content: {errorContent}");
                return new List<FeedbackResponse>();
            }

            // OData returns data in a wrapper object with "value" property
            var odataResponse = await response.Content.ReadFromJsonAsync<ODataResponse<FeedbackResponse>>();
            return odataResponse?.Value ?? new List<FeedbackResponse>();
        }
        public async Task<(IEnumerable<FeedbackResponse> data, int totalCount)> GetByStadiumIdPagedAsync(int stadiumId, int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;

            // ✅ Thêm $skip, $top, $orderby vào OData query
            var response = await _httpClient.GetAsync($"odata/FeedbackOData?$filter=stadiumId eq {stadiumId}&$skip={skip}&$top={pageSize}&$count=true&$orderby=createdAt desc");

            Console.WriteLine($"[FeedbackService] GET with pagination => {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[FeedbackService] Error content: {errorContent}");
                return (new List<FeedbackResponse>(), 0);
            }

            // ✅ Parse OData response để lấy data + count
            var odataResponse = await response.Content.ReadFromJsonAsync<ODataResponse<FeedbackResponse>>();

            return (odataResponse?.Value ?? new List<FeedbackResponse>(), odataResponse?.Count ?? 0);
        }
        public async Task<IEnumerable<FeedbackResponse>> GetByStadiumIdWithAuthAsync(int stadiumId, string accessToken)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.GetAsync($"feedback/stadium/{stadiumId}");
            Console.WriteLine($"[FeedbackService] GET feedback/stadium/{stadiumId} => {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[FeedbackService] Error content: {errorContent}");
                return new List<FeedbackResponse>();
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<FeedbackResponse>>()
                   ?? new List<FeedbackResponse>();
        }

        public async Task<(IEnumerable<FeedbackResponse> data, int totalCount)> GetAllWithOdataAsync(
            string accessToken,
            int skip = 0,
            int top = 10,
            string? filter = null,
            string? orderBy = "createdAt desc")
        {
            // Set Authorization header trước khi gọi OData (nếu backend OData cần auth)
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                AddBearerAccessToken(accessToken);
            }

            var query = new List<string>
            {
                $"$skip={skip}",
                $"$top={top}",
                "$count=true"
            };

            if (!string.IsNullOrWhiteSpace(filter))
                query.Add($"$filter={filter}");

            if (!string.IsNullOrWhiteSpace(orderBy))
                query.Add($"$orderby={orderBy}");

            var url = "odata/FeedbackOData?" + string.Join("&", query);

            var response = await _httpClient.GetAsync(url);
            Console.WriteLine($"[FeedbackService] GET {url} => {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[FeedbackService] Error content: {errorContent}");
                return (new List<FeedbackResponse>(), 0);
            }

            var odataResponse = await response.Content.ReadFromJsonAsync<ODataResponse<FeedbackResponse>>();
            return (odataResponse?.Value ?? new List<FeedbackResponse>(), odataResponse?.Count ?? 0);
        }

        public async Task<bool> CheckCompletedAsync(string accessToken, int userId, int stadiumId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var resp = await _httpClient.GetAsync($"booking/check-completed/{userId}/{stadiumId}");
            return resp.IsSuccessStatusCode;
        }
    }
}