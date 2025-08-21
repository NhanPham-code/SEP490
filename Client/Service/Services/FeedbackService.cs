    using FeedbackAPI.DTOs;
    using Service.BaseService;
    using Service.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
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
                var response = await _httpClient.GetAsync("feedback"); // Fixed: removed "api/" prefix
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
                var response = await _httpClient.GetAsync($"feedback/{id}"); // Fixed: removed "api/" prefix
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"[FeedbackService] GetByIdAsync failed: {response.StatusCode}");
                    return null;
                }
                return await response.Content.ReadFromJsonAsync<FeedbackResponse>();
            }

            public async Task<FeedbackResponse?> CreateAsync(CreateFeedback dto, string accessToken)
            {
                AddBearerAccessToken(accessToken);
                var response = await _httpClient.PostAsJsonAsync("feedback", dto); // Fixed: removed "api/" prefix
                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[FeedbackService] CreateAsync failed: {response.StatusCode} - {errorMessage}");
                    throw new Exception($"API CreateFeedback failed: {errorMessage}");
                }
                return await response.Content.ReadFromJsonAsync<FeedbackResponse>();
            }

            public async Task<bool> UpdateAsync(string accessToken, int id, UpdateFeedback dto)
            {
                AddBearerAccessToken(accessToken);
                var response = await _httpClient.PutAsJsonAsync($"feedback/{id}", dto); // Fixed: removed "api/" prefix
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"[FeedbackService] UpdateAsync failed: {response.StatusCode}");
                }
                return response.IsSuccessStatusCode;
            }

            public async Task<bool> DeleteAsync(string accessToken, int id)
            {
                AddBearerAccessToken(accessToken);
                var response = await _httpClient.DeleteAsync($"feedback/{id}"); // Fixed: removed "api/" prefix
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"[FeedbackService] DeleteAsync failed: {response.StatusCode}");
                }
                return response.IsSuccessStatusCode;
            }

            // FIXED VERSION - with proper authentication and path
            public async Task<IEnumerable<FeedbackResponse>> GetByStadiumIdAsync(int stadiumId)
            {
                // Option 1: If this endpoint doesn't require authentication (public data)
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

            // Alternative version if authentication is required
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
        }
    }