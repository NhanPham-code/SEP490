using DTOs.StadiumDTO;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
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

        public async Task<ReadStadiumImageDTO> AddStadiumImageAsync(CreateStadiumImageDTO dto)
        {
            using var form = new MultipartFormDataContent();

            // File
            form.Add(new StreamContent(dto.ImageUrl.OpenReadStream()), "ImageUrl", dto.ImageUrl.FileName);

            // StadiumId
            form.Add(new StringContent(dto.StadiumId.ToString()), "StadiumId");

            // UploadedAt
            form.Add(new StringContent(DateTime.Now.ToString("o")), "UploadedAt");

            // Gọi API upload
            var response = await _httpClient.PostAsync("/images/upload", form);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ReadStadiumImageDTO>();
            return result!;
        }

        public async Task<bool> DeleteStadiumImageAsync(int stadiumId)
        {
            var response = await _httpClient.DeleteAsync($"/images?id={stadiumId}");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadAsStringAsync() == "true";
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