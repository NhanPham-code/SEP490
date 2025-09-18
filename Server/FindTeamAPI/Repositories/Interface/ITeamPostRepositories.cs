using FindTeamAPI.Models;

namespace FindTeamAPI.Repositories.Interface
{
    public interface ITeamPostRepositories
    {
        Task<IEnumerable<TeamPost>> GetAllTeamPostsAsync();
        Task<TeamPost> GetTeamPostByIdAsync(int postId);
        Task<TeamPost> CreateTeamPostAsync(TeamPost teamPost);
        Task<TeamPost> UpdateTeamPostAsync(TeamPost teamPost);
        Task<bool> DeleteTeamPostAsync(int postId);
        Task<bool> IsTeamPostExistsAsync(int postId);
        IQueryable<TeamPost> GetAllTeamPostsQueryableAsync();
        IQueryable<TeamPost> GetAllTeamPostsQueryableByIdAsync(int userId);
    }
}
