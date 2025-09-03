using StadiumAPI.Data;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;

namespace StadiumAPI.Repositories
{
    public class StadiumVideoRepositories : IStadiumVideosRepositories
    {
        private readonly IStadiumImagesRepositories _stadiumImagesRepositories;
        private readonly StadiumDbContext _context;

        public StadiumVideoRepositories(IStadiumImagesRepositories stadiumImagesRepositories, StadiumDbContext stadiumDbContext)
        {
            _stadiumImagesRepositories = stadiumImagesRepositories;
            _context = stadiumDbContext;
        }

        public Task<StadiumVideos> AddVideoAsync(StadiumVideos image)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteVideoAsync(List<StadiumVideos> stadiumVideos)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteVIdeoByStadiumIdAsync(int stadiumId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StadiumVideos>> GetAllStadiumVideoByStadiumId(int stadiumId)
        {
            throw new NotImplementedException();
        }

        public Task<StadiumVideos> GetVideoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StadiumVideos> UpdateVideoAsync(int id, StadiumVideos image)
        {
            throw new NotImplementedException();
        }
    }
}