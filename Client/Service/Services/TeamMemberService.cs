using FindTeamAPI.DTOs;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<ReadTeamMemberDTO> AddTeamMember(CreateTeamMemberDTO createTeamMemberDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeamMember(int teamId, int postId)
        {
            throw new NotImplementedException();
        }

        public Task<ReadTeamMemberDTO> GetAllTeamMemberByPostId(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<ReadTeamMemberDTO> GetTeamMmeberById()
        {
            throw new NotImplementedException();
        }

        public Task<ReadTeamMemberDTO> UpdateTeamMember(UpdateTeamMemberDTO updateTeamMemberDTO)
        {
            throw new NotImplementedException();
        }
    }
}
