using DTOs.StadiumDTO;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CourtService : ICourtService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private string token = string.Empty;

        public CourtService(GatewayHttpClient gatewayHttpClient, ITokenService tokenService)
        {
            _httpClient = gatewayHttpClient.Client;
            _tokenService = tokenService;
            token = _tokenService.GetAccessTokenFromCookie();
        }

        public void AddBearerAccessToken()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ReadCourtDTO> CreateCourtAsync(CreateCourtDTO courtDto)
        {
            AddBearerAccessToken();
            var response = await _httpClient.PostAsJsonAsync("/courts/addCourt", courtDto);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ReadCourtDTO>();
        }

        public async Task<bool> DeleteCourtAsync(int id)
        {
            AddBearerAccessToken();
            var response = await _httpClient.DeleteAsync($"/courts/Delete?id={id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync() == "true";
        }

        public async Task<IEnumerable<ReadCourtDTO>> GetAllCourtsAsync(int stadiumId)
        {
            var response = await _httpClient.GetAsync($"/courts/getByIdStadium?stadiumId={stadiumId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<ReadCourtDTO>>();
        }

        public async Task<ReadCourtDTO> GetCourtByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/courts/getById?id={id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ReadCourtDTO>();
        }

        public async Task<ReadCourtDTO> UpdateCourtAsync(int id, UpdateCourtDTO courtDto)
        {
            AddBearerAccessToken();
            var response = await _httpClient.PutAsJsonAsync($"/courts/updateCourt?id={id}", courtDto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ReadCourtDTO>();
        }
    }
}