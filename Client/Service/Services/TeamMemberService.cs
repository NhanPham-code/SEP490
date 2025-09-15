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
    public class TeamMemberService : ITeamMemberService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        public TeamMemberService(GatewayHttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient.Client;
            _tokenService = tokenService;
        }

        public void InitializeAsync()
        {
            var token = _tokenService.GetAccessTokenFromCookie();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<ReadTeamMemberDTO> AddTeamMember(CreateTeamMemberDTO createTeamMemberDTO)
        {
            InitializeAsync();
            var response = await _httpClient.PostAsJsonAsync("/AddNewTeamMember", createTeamMemberDTO);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReadTeamMemberDTO>();
        }

        public async Task<bool> DeleteTeamMember(int teamId, int postId)
        {
            InitializeAsync();
            var response = await _httpClient.DeleteAsync($"/DeleteTeamMember?teamMemberId={teamId}&postId={postId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync() == "true";
        }

        public async Task<ReadTeamMemberDTO> GetAllTeamMemberByPostId(int postId)
        {
            InitializeAsync();
            var response = await _httpClient.GetAsync($"/GetAllTeamMember?postId={postId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReadTeamMemberDTO>();
        }

        public async Task<ReadTeamMemberDTO> GetTeamMemberById(int postId, int teamId)
        {
            InitializeAsync();
            var response = await _httpClient.GetAsync($"/GetTeamMemberByPostIdAndId?teamId={postId}&postId={teamId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReadTeamMemberDTO>();
        }

        public async Task<ReadTeamMemberDTO> UpdateTeamMember(UpdateTeamMemberDTO updateTeamMemberDTO)
        {
            InitializeAsync();
            var response = await _httpClient.PutAsJsonAsync("/UpdateTeamMember", updateTeamMemberDTO);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReadTeamMemberDTO>();
        }
    }
}
