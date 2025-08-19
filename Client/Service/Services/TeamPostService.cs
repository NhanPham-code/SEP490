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

        public async Task<ReadTeamPostDTO> CreateTeamPost(CreateTeamPostDTO createTeamPostDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/CreateTeamPost", createTeamPostDTO);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReadTeamPostDTO>();
        }

        public async Task DeleteTeamPost(int postId)
        {
            var response = await _httpClient.DeleteAsync($"/DeleteTeamPost?postId={postId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync() == "true";
        }

        public async Task<string> GetOdataTeamPostAsync(string url)
        {
            var response = await _httpClient.GetAsync("/odata/TeamPost" + url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<ReadTeamPostDTO> UpdateTeamPost(UpdateTeamPostDTO updateTeamPostDTO)
        {
            throw new NotImplementedException();
        }
    }
}
