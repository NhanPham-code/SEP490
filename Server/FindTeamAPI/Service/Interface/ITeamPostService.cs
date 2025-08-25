using FindTeamAPI.DTOs;
using FindTeamAPI.Models;

namespace FindTeamAPI.Service.Interface
{
    public interface ITeamPostService
    {
        Task<ReadTeamPostDTO> CreateTeamPostAsync(CreateTeamPostDTO createTeamPostDto);
        Task<ReadTeamPostDTO> UpdateTeamPostAsync(UpdateTeamPostDTO updateTeamPostDto);
        Task<bool> DeleteTeamPostAsync(int postId);
        IQueryable<TeamPost> GetAllTeamPostsQueryableAsync();
    }
}
