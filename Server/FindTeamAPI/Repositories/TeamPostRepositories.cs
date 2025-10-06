using FindTeamAPI.Data;
using FindTeamAPI.Models;
using FindTeamAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FindTeamAPI.Repositories
{
    public class TeamPostRepositories : ITeamPostRepositories
    {
        private readonly FindTeamDbContext _context;
        public TeamPostRepositories(FindTeamDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TeamPost>> GetAllTeamPostsAsync()
        {
            return await _context.TeamPosts.Select(t => t).ToListAsync();
        }
        public async Task<TeamPost> GetTeamPostByIdAsync(int postId)
        {
            return await _context.TeamPosts
                .FirstOrDefaultAsync(tp => tp.Id == postId);
        }
        public async Task<TeamPost> CreateTeamPostAsync(TeamPost teamPost)
        {
            teamPost.CreatedAt = DateTime.UtcNow;
            var tempost = await _context.TeamPosts.AddAsync(teamPost);
            await _context.SaveChangesAsync();
            return teamPost;
        }
        public async Task<TeamPost> UpdateTeamPostAsync(TeamPost teamPost)
        {
            var existingPost = await GetTeamPostByIdAsync(teamPost.Id);
            if (existingPost == null) return null;
            existingPost.Title = teamPost.Title;
            existingPost.Description = teamPost.Description;
            existingPost.NeededPlayers = teamPost.NeededPlayers;
            existingPost.JoinedPlayers = teamPost.JoinedPlayers;
            existingPost.PricePerPerson = teamPost.PricePerPerson;
            existingPost.UpdatedAt = DateTime.UtcNow;
            _context.TeamPosts.Update(existingPost);
            await _context.SaveChangesAsync();
            return teamPost;
        }
        public async Task<bool> DeleteTeamPostAsync(int postId)
        {
            var teamPost = await GetTeamPostByIdAsync(postId);
            if (teamPost == null) return false;
            _context.TeamPosts.Remove(teamPost);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> IsTeamPostExistsAsync(int postId)
        {
            return await _context.TeamPosts
                .AnyAsync(tp => tp.Id == postId);
        }
        public IQueryable<TeamPost> GetAllTeamPostsQueryableAsync()
        {
            return _context.TeamPosts.AsQueryable();
        }
        public IQueryable<TeamPost> GetAllTeamPostsQueryableByIdAsync(int userId)
        {
            return _context.TeamPosts.Include(tp => tp.TeamMembers.Where(p => p.UserId == userId))
                .AsQueryable();
        }
    }
}
