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
    public class CourtService : ICourtService
    {
        private readonly HttpClient _httpClient;
        public CourtService(GatewayHttpClient gatewayHttpClient) { 
        _httpClient = gatewayHttpClient.Client;
        }

        public async Task<ReadCourtDTO> CreateCourtAsync(CreateCourtDTO courtDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/courts/addCourt", courtDto);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ReadCourtDTO>();
        }

        public async Task<bool> DeleteCourtAsync(int id)
        {
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
            var response = await  _httpClient.GetAsync($"/courts/getById?id={id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ReadCourtDTO>();
        }

        public async Task<ReadCourtDTO> UpdateCourtAsync(int id, UpdateCourtDTO courtDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"/courts/updateCourt?id={id}", courtDto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ReadCourtDTO>();
        }
    }
}
