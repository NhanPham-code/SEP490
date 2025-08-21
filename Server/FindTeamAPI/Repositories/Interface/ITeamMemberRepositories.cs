using FindTeamAPI.Models;

namespace FindTeamAPI.Repositories.Interface
{
    public interface ITeamMemberRepositories
    {
        Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync(int teamId);
        Task<TeamMember> GetTeamMemberByIdAsync(int teamId, int memberId);
        Task<TeamMember> CreateTeamMemberAsync(TeamMember teamMember);
        Task<TeamMember> UpdateTeamMemberAsync(TeamMember teamMember);
        Task<bool> DeleteTeamMemberAsync(int teamId, int memberId);
        Task<bool> IsTeamMemberExistsAsync(int teamId);
        Task<bool> DeleteMemberByMemberId(int teamId, int memberId, int UserId);
    }
}
