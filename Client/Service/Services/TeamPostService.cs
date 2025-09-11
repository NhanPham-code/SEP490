using FindTeamAPI.DTOs;
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
    public class TeamPostService : ITeamPostService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        public TeamPostService(GatewayHttpClient httpClient,ITokenService tokenService)
        {
            _httpClient = httpClient.Client;
            _tokenService = tokenService;
        }

        public void InitializeAsync()
        {
            var token = _tokenService.GetAccessTokenFromCookie();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ReadTeamPostDTO> CreateTeamPost(CreateTeamPostDTO createTeamPostDTO)
        {
            InitializeAsync();
            var response = await _httpClient.PostAsJsonAsync("/CreateTeamPost", createTeamPostDTO);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReadTeamPostDTO>();
        }

        public async Task<bool> DeleteTeamPost(int postId)
        {
            InitializeAsync();
            var response = await _httpClient.DeleteAsync($"/DeleteTeamPost?postId={postId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync() == "true";
        }

        public async Task<string> GetOdataTeamPostAsync(string url)
        {
            InitializeAsync();
            var response = await _httpClient.GetAsync("/odata/TeamPost" + url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<ReadTeamPostDTO> UpdateTeamPost(UpdateTeamPostDTO updateTeamPostDTO)
        {
            InitializeAsync();
            var response = await _httpClient.PutAsJsonAsync("/UpdateTeamPost", updateTeamPostDTO);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReadTeamPostDTO>();
        }
    }
}
