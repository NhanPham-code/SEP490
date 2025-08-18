using FeedbackAPI.DTOs;
using FeedbackAPI.Service;
using System.Net.Http.Json;
using Service.Interfaces;
using Service.BaseService;

namespace FeedbackClient.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly HttpClient _httpClient;

        public FeedbackService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<FeedbackResponse>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FeedbackResponse>>("api/feedback")
                   ?? new List<FeedbackResponse>();
        }

        public async Task<FeedbackResponse?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<FeedbackResponse>($"api/feedback/{id}");
        }

        public async Task<FeedbackResponse?> CreateAsync(CreateFeedback dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/feedback", dto);
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<FeedbackResponse>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateFeedback dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/feedback/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/feedback/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
