using DTOs.StadiumDTO;
using Org.BouncyCastle.Crypto;
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
    public class StadiumImageService : IStadiumImageService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private string token = string.Empty;

        public StadiumImageService(GatewayHttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient.Client;
            _tokenService = tokenService;
            token = _tokenService.GetAccessTokenFromCookie();
        }

        public async Task<List<ReadStadiumImageDTO>> AddStadiumImageAsync(List<CreateStadiumImageDTO> dtos)
        {
            if (dtos == null || !dtos.Any() || dtos.All(dto => dto.ImageUrl == null || dto.ImageUrl.Length == 0))
            {
                throw new ArgumentException("No valid images provided.");
            }

            using var form = new MultipartFormDataContent();

            for (int i = 0; i < dtos.Count; i++)
            {
                var dto = dtos[i];
                if (dto.ImageUrl == null || dto.ImageUrl.Length == 0)
                {
                    Console.WriteLine($"Skipping DTO {i}: ImageUrl is null or empty.");
                    continue;
                }

                form.Add(new StringContent(dto.StadiumId.ToString()), $"[{i}].stadiumId");
                form.Add(new StreamContent(dto.ImageUrl.OpenReadStream()), $"[{i}].imageUrl", dto.ImageUrl.FileName);
                form.Add(new StringContent(dto.UploadedAt.ToString("o")), $"[{i}].uploadedAt");
            }

            var response = await _httpClient.PostAsync("/images/upload", form);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}");
                throw new HttpRequestException($"Request failed with status {response.StatusCode}: {errorContent}");
            }

            var result = await response.Content.ReadFromJsonAsync<List<ReadStadiumImageDTO>>();
            return result ?? new List<ReadStadiumImageDTO>();
        }

        public async Task<bool> DeleteStadiumImageAsync(int stadiumId)
        {
            var response = await _httpClient.DeleteAsync($"/images/delete?stadiumId={stadiumId}");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadAsStringAsync() == "true";
        }

        public async Task<bool> DeleteStadiumImageByIdAsync(int[] ids)
        {
            var json = JsonSerializer.Serialize(ids); // [1,2,3]
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "images/deleteById"), // route gateway
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            return bool.TryParse(resultString, out var result) && result;
        }

        public async Task<IEnumerable<ReadStadiumImageDTO>> GetStadiumImagesAsync(int stadiumId)
        {
            var response = await _httpClient.GetAsync($"/images/getAllByStadiumId?stadiumId={stadiumId}");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<ReadStadiumImageDTO>>();
            return result!;
        }

        public async Task<ReadStadiumImageDTO> UpdateStadiumImageAsync(int stadiumId, UpdateStadiumImageDTO updateStadiumImageDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"/images/update?stadiumId={stadiumId}", updateStadiumImageDTO);
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadFromJsonAsync<ReadStadiumImageDTO>();
        }
    }
}