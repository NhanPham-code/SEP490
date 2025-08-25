using Service.BaseService;
using Service.Interfaces;
using StadiumAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CourtRelationService : ICourtRelationService
    {

        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private string token = string.Empty;

        public CourtRelationService(GatewayHttpClient gatewayHttpClient, ITokenService tokenService)
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

        public async Task<IEnumerable<ReadCourtRelationDTO>> CreateCourtRelation(int[] childCourt, int parentCourt)
        {
            AddBearerAccessToken();
            var response = await _httpClient.PostAsJsonAsync($"/AddCourtRelation?parentCourt={parentCourt}", childCourt);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<ReadCourtRelationDTO>>();
        }

        public async Task<bool> DeleteCourtRelation(int parentId)
        {
            AddBearerAccessToken();
            var response = await _httpClient.DeleteAsync($"/DeleteCourtRelation?parentId={parentId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync() == "true";
        }

        public async Task<IEnumerable<ReadCourtRelationDTO>> GetAllCourtRelationBychildId(int childId)
        {
            var response = await _httpClient.GetAsync($"/GetAllCourtRelationChild?childId={childId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ReadCourtRelationDTO>>();
        }

        public async Task<IEnumerable<ReadCourtRelationDTO>> GetAllCourtRelationByParentId(int parentId)
        {
            var response = await _httpClient.GetAsync($"/GetAllCourtRelationParent?parentId{parentId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ReadCourtRelationDTO>>();
        }

        public async Task<IEnumerable<ReadCourtRelationDTO>> UpdateCourtRelation(int[] childCourt, int parentCourt)
        {
            AddBearerAccessToken();
            var response = await _httpClient.PutAsJsonAsync($"/UpdateCourtRelation?=parentId{parentCourt}", childCourt);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<ReadCourtRelationDTO>>();
        }
    }
}
