using Microsoft.EntityFrameworkCore;
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

        public async Task<StadiumVideos> AddVideoAsync(StadiumVideos videos)
        {
            _context.ChangeTracker.Clear();
            videos.UploadedAt = DateTime.UtcNow;
            await _context.StadiumVideos.AddAsync(videos);
            await _context.SaveChangesAsync();
            return videos;
        }

        public async Task<bool> DeleteVideoAsync(List<StadiumVideos> stadiumVideos)
        {
            if (stadiumVideos.Count == 0)
                throw new KeyNotFoundException("No videos found with the given IDs.");
            _context.ChangeTracker.Clear();
            _context.RemoveRange(stadiumVideos);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVIdeoByStadiumIdAsync(int stadiumId)
        {
            _context.ChangeTracker.Clear();
            var context = _context.StadiumVideos.Where(i => i.StadiumId.Equals(stadiumId));
            _context.RemoveRange(context);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<StadiumVideos>> GetAllStadiumVideoByStadiumId(int stadiumId)
        {
            var videos = _context.StadiumVideos.Where(i => i.StadiumId.Equals(stadiumId));
            return await Task.FromResult(videos.AsEnumerable());
        }

        public async Task<StadiumVideos> GetVideoByIdAsync(int id)
        {
            var video = await _context.StadiumVideos.FirstOrDefaultAsync(i => i.Id.Equals(id));
            if (video == null)
                throw new KeyNotFoundException($"Video with ID {id} not found.");
            return video;
        }

        public async Task<StadiumVideos> UpdateVideoAsync(int id, StadiumVideos image)
        {
            var existingVideo = await _context.StadiumVideos.FindAsync(id);
            _context.ChangeTracker.Clear();
            if (existingVideo == null)
                throw new KeyNotFoundException($"Video with ID {id} not found.");
            _context.Update(image);
            await _context.SaveChangesAsync();
            return existingVideo;
        }
    }
}