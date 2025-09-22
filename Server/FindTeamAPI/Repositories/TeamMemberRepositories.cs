using FindTeamAPI.Data;
using FindTeamAPI.Models;
using FindTeamAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FindTeamAPI.Repositories
{
    public class TeamMemberRepositories : ITeamMemberRepositories
    {
        private readonly FindTeamDbContext _context;
        public TeamMemberRepositories(FindTeamDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync(int teamId)
        {
            
            return await _context.TeamMembers.Where(t => t.TeamPostId.Equals(teamId)).ToListAsync();
        }
        public async Task<TeamMember> GetTeamMemberByIdAsync(int memberId, int teamId)
        {
            return await _context.TeamMembers
                .FirstOrDefaultAsync(tm => tm.Id == memberId && tm.TeamPostId.Equals(teamId));
        }
        public async Task<TeamMember> CreateTeamMemberAsync(TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();
            return teamMember;
        }
        public async Task<TeamMember> UpdateTeamMemberAsync(TeamMember teamMember)
        {
            _context.ChangeTracker.Clear();
            var member = await _context.TeamMembers.FirstOrDefaultAsync(m => m.Id == teamMember.Id);
            member.role = teamMember.role;
            _context.TeamMembers.Update(member);
            await _context.SaveChangesAsync();
            return teamMember;
        }
        public async Task<bool> DeleteTeamMemberAsync(int memberId, int teamId)
        {
            var teamMember = await GetTeamMemberByIdAsync(memberId, teamId);
            if (teamMember == null) return false;
        
                _context.TeamMembers.Remove(teamMember);
                await _context.SaveChangesAsync();
                return true;

        }
        public async Task<bool> DeleteMemberByMemberId(int memberId, int teamId, int userId)
        {
            var member = await _context.TeamMembers.FirstOrDefaultAsync(m => m.Id == memberId
            && m.TeamPostId == teamId && m.UserId == userId);
            if (member == null) return false;
            _context.TeamMembers.Remove(member);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> IsTeamMemberExistsAsync(int memberId)
        {
            return await _context.TeamMembers
                .AnyAsync(tm => tm.Id == memberId);
        }

    }
}
