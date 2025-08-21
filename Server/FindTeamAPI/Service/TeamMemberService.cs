using AutoMapper;
using FindTeamAPI.DTOs;
using FindTeamAPI.Models;
using FindTeamAPI.Repositories.Interface;
using FindTeamAPI.Service.Interface;

namespace FindTeamAPI.Service
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepositories _teamMemberRepositories;
        private readonly IMapper _mapper;
        public TeamMemberService(ITeamMemberRepositories teamMemberRepositories, IMapper mapper)
        {
            _teamMemberRepositories = teamMemberRepositories;
            _mapper = mapper;
        }
        public async Task<ReadTeamMemberDTO> CreateTeamMemberAsync(CreateTeamMemberDTO createTeamMemberDto)
        {
            return _mapper.Map<ReadTeamMemberDTO>(await _teamMemberRepositories.CreateTeamMemberAsync(_mapper.Map<TeamMember>(createTeamMemberDto)));
        }

        public async Task<bool> DeleteTeamMemberAsync(int teamId, int memberId)
        {
            return await _teamMemberRepositories.DeleteTeamMemberAsync(teamId, memberId);
        }

        public async Task<IEnumerable<ReadTeamMemberDTO>> GetAllTeamMembersAsync(int teamId)
        {
            return _mapper.Map<IEnumerable<ReadTeamMemberDTO>>(await _teamMemberRepositories.GetAllTeamMembersAsync(teamId));
        }

        public async Task<ReadTeamMemberDTO> GetTeamMemberByIdAsync(int teamId, int memberId)
        {
            return _mapper.Map<ReadTeamMemberDTO>(await _teamMemberRepositories.GetTeamMemberByIdAsync(teamId, memberId));
        }

        public async Task<ReadTeamMemberDTO> UpdateTeamMemberAsync(UpdateTeamMemberDTO updateTeamMemberDto)
        {
            return _mapper.Map<ReadTeamMemberDTO>(await _teamMemberRepositories.UpdateTeamMemberAsync(_mapper.Map<TeamMember>(updateTeamMemberDto)));
        }
        public async Task<bool> DeleteMemberByMemberId(int teamMemberId, int teamPostID, int userId)
        {
            return await _teamMemberRepositories.DeleteMemberByMemberId(teamMemberId, teamPostID, userId);
        }
    }
}
