using StadiumAPI.Data;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;

namespace StadiumAPI.Repositories
{
    public class CourtsRepositories : ICourtsRepositories
    {
        private readonly StadiumDbContext _context;
        public CourtsRepositories(StadiumDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<Courts> CreateCourtAsync(Courts court)
        {
            if (court == null)
            {
                throw new ArgumentNullException(nameof(court));
            }
            _context.Courts.Add(court);
            return _context.SaveChangesAsync().ContinueWith(t => court);
        }

        public Task<bool> DeleteCourtAsync(int id)
        {
            var court = _context.Courts.Find(id);
            if (court == null)
            {
                return Task.FromResult(false);
            }
            _context.Courts.Remove(court);
            return _context.SaveChangesAsync().ContinueWith(t => true);
        }

        public Task<IEnumerable<Courts>> GetAllCourtsAsync(int stadiumId)
        {
            if (stadiumId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stadiumId), "Stadium ID must be greater than zero.");
            }
            return Task.FromResult(_context.Courts.Where(c => c.StadiumId == stadiumId).AsEnumerable());
        }

        public Task<Courts> GetCourtByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");
            }
            var court = _context.Courts.Find(id);
            return Task.FromResult(court);
        }

        public Task<Courts> UpdateCourtAsync(int id, Courts court)
        {
            if (court == null)
            {
                throw new ArgumentNullException(nameof(court));
            }
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");
            }
            var existingCourt = _context.Courts.Find(id);
            if (existingCourt == null)
            {
                throw new KeyNotFoundException($"Court with ID {id} not found.");
            }
            existingCourt.Name = court.Name;
            existingCourt.SportType = court.SportType;
            existingCourt.PricePerHour = court.PricePerHour;
            existingCourt.IsAvailable = court.IsAvailable;
            existingCourt.UpdatedAt = DateTime.UtcNow; // Update the timestamp
            _context.Courts.Update(existingCourt);
            return _context.SaveChangesAsync().ContinueWith(t => existingCourt);
        }
    }
}
