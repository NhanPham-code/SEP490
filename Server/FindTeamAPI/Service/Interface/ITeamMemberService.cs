using FindTeamAPI.DTOs;

namespace FindTeamAPI.Service.Interface
{
    public interface ITeamMemberService
    {
        Task<IEnumerable<ReadTeamMemberDTO>> GetAllTeamMembersAsync(int teamId);
        Task<ReadTeamMemberDTO> GetTeamMemberByIdAsync(int teamId, int memberId);
        Task<ReadTeamMemberDTO> CreateTeamMemberAsync(CreateTeamMemberDTO createTeamMemberDto);
        Task<ReadTeamMemberDTO> UpdateTeamMemberAsync(UpdateTeamMemberDTO updateTeamMemberDto);
        Task<bool> DeleteMemberByMemberId(int teamMemberId, int teamPostID, int userId);
        Task<bool> DeleteTeamMemberAsync(int teamId, int memberId);
    }
}
