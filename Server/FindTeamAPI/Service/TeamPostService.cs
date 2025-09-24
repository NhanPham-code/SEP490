using AutoMapper;
using FindTeamAPI.DTOs;
using FindTeamAPI.Models;
using FindTeamAPI.Repositories.Interface;
using FindTeamAPI.Service.Interface;

namespace FindTeamAPI.Service
{
    public class TeamPostService : ITeamPostService
    {
        private readonly ITeamPostRepositories _teamPostRepositories;
        private readonly IMapper _mapper;
        public TeamPostService(ITeamPostRepositories teamPostRepositories, IMapper mapper)
        {
            _teamPostRepositories = teamPostRepositories;
            _mapper = mapper;
        }
        public async Task<ReadTeamPostDTO> CreateTeamPostAsync(CreateTeamPostDTO teamPost)
        {
            return _mapper.Map<ReadTeamPostDTO>(
                await _teamPostRepositories.CreateTeamPostAsync(
                    _mapper.Map<TeamPost>(teamPost)
                )
            );
        }
        public async Task<ReadTeamPostDTO> UpdateTeamPostAsync(UpdateTeamPostDTO teamPost)
        {
            return _mapper.Map<ReadTeamPostDTO>(
                await _teamPostRepositories.UpdateTeamPostAsync(
                    _mapper.Map<TeamPost>(teamPost)
                )
            );
        }
        public async Task<bool> DeleteTeamPostAsync(int postId)
        {
            return await _teamPostRepositories.DeleteTeamPostAsync(postId);
        }
        public IQueryable<TeamPost> GetAllTeamPostsQueryableByIdAsync(int userId)
        {
            return _teamPostRepositories.GetAllTeamPostsQueryableByIdAsync(userId);
        }
        public IQueryable<TeamPost> GetAllTeamPostsQueryableAsync()
        {
            return _teamPostRepositories.GetAllTeamPostsQueryableAsync();
        }
    }
}
