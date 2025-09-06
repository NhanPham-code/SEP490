using DTOs.StadiumDTO;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StadiumVideoService : IStadiumVideoSetvice
    {
        private readonly HttpClient _httpClient;

        public StadiumVideoService(GatewayHttpClient httpClient)
        {
            _httpClient = httpClient.Client;
        }

        public async Task<IEnumerable<ReadStadiumVideoDTO>> AddStadiumVideoAsync(List<CreateStadiumVideoDTO> dtos)
        {
            using var form = new MultipartFormDataContent();

            for (int i = 0; i < dtos.Count; i++)
            {
                var dto = dtos[i];
                form.Add(new StringContent(dto.StadiumId.ToString()), $"[{i}].StadiumId");
                form.Add(new StreamContent(dto.VideoUrl.OpenReadStream()), $"[{i}].VideoUrl", dto.VideoUrl.FileName);
            }

            var response = await _httpClient.PostAsync("/AddStadiumVideo", form);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ReadStadiumVideoDTO>>();
        }

        public async Task<bool> DeleteAllVideosByStadiumId(int stadiumId)
        {
            var response = await _httpClient.DeleteAsync($"/deleteStadiumVideosByStadiumId?stadiumId={stadiumId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> DeleteStadiumVideoAsync(int[] id)
        {
            var json = JsonSerializer.Serialize(id); // [1,2,3]
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/DeleteStadiumVideoById"), // route gateway
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            return bool.TryParse(resultString, out var result) && result;
        }

        public async Task<IEnumerable<ReadStadiumVideoDTO>> GetAllVideoByStadiumId(int stadiumId)
        {
            var response = await _httpClient.GetAsync($"/AllStadiumVideos?stadiumId={stadiumId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ReadStadiumVideoDTO>>();
        }

        public async Task<ReadStadiumVideoDTO> GetStadiumVideoByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/StadiumVideoById?id={id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReadStadiumVideoDTO>();
        }

        public async Task<ReadStadiumVideoDTO> UpdateStadiumVideoAsync(int id, CreateStadiumVideoDTO stadiumVideoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"/UpdateStadiumVideo?id={id}", stadiumVideoDTO);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReadStadiumVideoDTO>();
        }
    }
}