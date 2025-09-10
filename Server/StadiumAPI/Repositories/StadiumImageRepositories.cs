using Microsoft.EntityFrameworkCore;
using StadiumAPI.Data;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;
using System.Linq;

namespace StadiumAPI.Repositories
{
    public class StadiumImageRepositories : IStadiumImagesRepositories
    {
        private readonly StadiumDbContext _context;

        public StadiumImageRepositories(StadiumDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<StadiumImages> AddImageAsync(StadiumImages image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            _context.StadiumImages.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<bool> DeleteImageAsync(List<StadiumImages> stadiumImages)
        {
            if (stadiumImages.Count == 0)
                throw new KeyNotFoundException("No images found with the given IDs.");
            _context.ChangeTracker.Clear();
            _context.StadiumImages.RemoveRange(stadiumImages);

            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> DeleteImageByStadiumIdAsync(int stadiumId)
        {
            if (stadiumId <= 0)
                throw new ArgumentException("Invalid image ID.", nameof(stadiumId));
            var image = _context.StadiumImages.Where(i => i.StadiumId.Equals(stadiumId));
            if (image == null)
                throw new KeyNotFoundException($"Image with ID {stadiumId} not found.");
            _context.StadiumImages.RemoveRange(image);
            return _context.SaveChangesAsync().ContinueWith(t => true);
        }

        public async Task<IEnumerable<StadiumImages>> GetAllImagesAsync(int stadiumId)
        {
            if (stadiumId <= 0)
                throw new ArgumentException("Invalid stadium ID.", nameof(stadiumId));
            return await _context.StadiumImages.Where(i => i.StadiumId.Equals(stadiumId)).ToListAsync();
        }

        public Task<StadiumImages> GetImageByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid image ID.", nameof(id));
            var image = _context.StadiumImages.Find(id);
            if (image == null)
                throw new KeyNotFoundException($"Image with ID {id} not found.");
            return Task.FromResult(image);
        }

        public Task<StadiumImages> UpdateImageAsync(int id, StadiumImages image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (id <= 0)
                throw new ArgumentException("Invalid image ID.", nameof(id));
            var existingImage = _context.StadiumImages.Find(id);
            if (existingImage == null)
                throw new KeyNotFoundException($"Image with ID {id} not found.");
            existingImage.ImageUrl = image.ImageUrl; // Assuming StadiumImages has an ImageUrl property
            existingImage.StadiumId = image.StadiumId; // Assuming StadiumImages has a StadiumId property
            _context.Entry(existingImage).State = EntityState.Modified;
            return _context.SaveChangesAsync().ContinueWith(t => existingImage);
        }
    }
}