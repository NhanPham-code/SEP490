using FindTeamAPI.DTOs;
using FindTeamAPI.Models;

namespace FindTeamAPI.Service.Interface
{
    public interface ITeamPostService
    {
        Task<IEnumerable<ReadTeamPostDTO>> GetAllTeamPostsAsync(int teamId);
        Task<ReadTeamPostDTO> GetTeamPostByIdAsync(int teamId, int postId);
        Task<ReadTeamPostDTO> CreateTeamPostAsync(CreateTeamPostDTO createTeamPostDto);
        Task<ReadTeamPostDTO> UpdateTeamPostAsync(UpdateTeamPostDTO updateTeamPostDto);
        Task<bool> DeleteTeamPostAsync(int teamId, int postId);
        Task<bool> IsTeamPostExistsAsync(int teamId, int postId);
        IQueryable<TeamPost> GetAllTeamPostsQueryableAsync(int teamId);
    }
}
