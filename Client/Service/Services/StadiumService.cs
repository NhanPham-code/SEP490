using DTOs.OData;
using DTOs.StadiumDTO;
using FindTeamAPI.DTOs;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public class StadiumService : IStadiumService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private string token = string.Empty;

        public StadiumService(GatewayHttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient.Client;
            _tokenService = tokenService;
            token = _tokenService.GetAccessTokenFromCookie();
        }

        public void AddBearerAccessToken()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ReadStadiumDTO> CreateStadiumAsync(CreateStadiumDTO stadiumDto)
        {
            AddBearerAccessToken();
            var response = await _httpClient.PostAsJsonAsync("/addStadium", stadiumDto);
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadFromJsonAsync<ReadStadiumDTO>();
        }

        public async Task<bool> DeleteStadiumAsync(int id)
        {
            AddBearerAccessToken();
            var response = await _httpClient.DeleteAsync($"/deleteStadium?id={id}");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadAsStringAsync() == "true";
        }

        public async Task<string> GetAllStadiumsAsync()
        {
            var response = await _httpClient.GetAsync("/odata/Stadium");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<ReadStadiumDTO> GetStadiumByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/getByIdStadium?id={id}");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadFromJsonAsync<ReadStadiumDTO>();
        }

        public async Task<string> SearchStadiumAsync(string searchTerm)
        {
            var response = await _httpClient.GetAsync("/odata/Stadium?$expand=StadiumVideos,Courts($select=Id,StadiumId,Name,SportType,PricePerHour,IsAvailable),StadiumImages($select=Id,StadiumId,ImageUrl)&$count=true" + searchTerm);
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ExportExcel()
        {
            var response = await _httpClient.GetAsync("/odata/Stadium?$expand=Courts($select=Id,StadiumId,Name,SportType,PricePerHour,IsAvailable)");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<OdataHaveCountResponse<ReadStadiumDTO>> GetSportType(string searchTerm)
        {
            var response = await _httpClient.GetAsync($"/odata/Stadium?$expand=StadiumVideos,Courts($select=SportType)&$filter=Courts/any(c: contains(tolower(c/SportType), '{searchTerm}'))&$top=0&$count=true");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            var stadium = await response.Content.ReadAsStringAsync();
            var newResponse = JsonConvert.DeserializeObject<OdataHaveCountResponse<ReadStadiumDTO>>(stadium);
            return newResponse;
        }
        public async Task<OdataHaveCountResponse<ReadStadiumDTO>> GetAllStadiumByListId(List<int> stadiumId)
        {
            var ids = string.Join(",", stadiumId);

            var response = await _httpClient.GetAsync($"/odata/Stadium?$expand=Courts($select=Id,StadiumId,Name,SportType,PricePerHour,IsAvailable),StadiumImages($select=Id,StadiumId,ImageUrl)&$count=true&$filter=Id in ({ids})");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            var stadium = await response.Content.ReadAsStringAsync();
            var newResponse = JsonConvert.DeserializeObject<OdataHaveCountResponse<ReadStadiumDTO>>(stadium);
            return newResponse;
        }
        // Lấy những sân chưa được duyệt
        public async Task<OdataHaveCountResponse<ReadStadiumDTO>> GetUnapprovedStadiums()
        {
            var response = await _httpClient.GetAsync($"/odata/Stadium?$filter=IsApproved eq false&$count=true");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            var stadium = await response.Content.ReadAsStringAsync();
            var newResponse = JsonConvert.DeserializeObject<OdataHaveCountResponse<ReadStadiumDTO>>(stadium);
            return newResponse;
        }
        // Lấy tổng số sân
        public async Task<OdataHaveCountResponse<ReadStadiumDTO>> GetTotalStadiums()
        {
            var response = await _httpClient.GetAsync($"/odata/Stadium?$count=true&$top=0");
            response.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            var stadium = await response.Content.ReadAsStringAsync();
            var newResponse = JsonConvert.DeserializeObject<OdataHaveCountResponse<ReadStadiumDTO>>(stadium);
            return newResponse;
        }

        public Task<ReadStadiumDTO> UpdateStadiumAsync(int id, UpdateStadiumDTO stadiumDto)
        {
            AddBearerAccessToken();
            var response = _httpClient.PutAsJsonAsync($"/updateStadium?id={id}", stadiumDto);
            response.Result.EnsureSuccessStatusCode(); // Nếu không 2xx → throw HttpRequestException
            return response.Result.Content.ReadFromJsonAsync<ReadStadiumDTO>();
        }
    }
}