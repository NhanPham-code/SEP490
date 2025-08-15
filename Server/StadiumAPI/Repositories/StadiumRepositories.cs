using Microsoft.EntityFrameworkCore;
using StadiumAPI.Data;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;

namespace StadiumAPI.Repositories
{
    public class StadiumRepositories : IStadiumRepositories
    {
        private readonly StadiumDbContext _context;
        public StadiumRepositories(StadiumDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Stadiums>> GetAllStadiumsAsync()
        {
            return await _context.Stadiums.ToListAsync();
        }
        public async Task<Stadiums> GetStadiumByIdAsync(int id)
        {
            return await _context.Stadiums.FindAsync(id) ?? throw new KeyNotFoundException($"Stadium with ID {id} not found.");
        }
        public async Task<Stadiums> CreateStadiumAsync(Stadiums stadiums)
        {
            if (stadiums == null) throw new ArgumentNullException(nameof(stadiums));
            _context.Stadiums.Add(stadiums);
            await _context.SaveChangesAsync();
            return stadiums;
        }
        public async Task<Stadiums> UpdateStadiumAsync(int id, Stadiums stadiums)
        {
            if (stadiums == null) throw new ArgumentNullException(nameof(stadiums));
            var existingStadium = await GetStadiumByIdAsync(id);
            existingStadium.Name = stadiums.Name;
            existingStadium.Address = stadiums.Address;
            existingStadium.Description = stadiums.Description;
            existingStadium.OpenTime = stadiums.OpenTime;
            existingStadium.CloseTime = stadiums.CloseTime;
            existingStadium.Latitude = stadiums.Latitude;
            existingStadium.Longitude = stadiums.Longitude;
            existingStadium.IsApproved = stadiums.IsApproved;
            existingStadium.UpdatedAt = DateTime.UtcNow;
            _context.Stadiums.Update(existingStadium);
            await _context.SaveChangesAsync();
            return existingStadium;
        }
        public async Task<bool> DeleteStadiumAsync(int id)
        {
            var stadium = await GetStadiumByIdAsync(id);
            if (stadium == null) return false;
            _context.Stadiums.Remove(stadium);
            await _context.SaveChangesAsync();
            return true;
        }
        public IQueryable<Stadiums> GetOdataStadiums()
        {
            return _context.Stadiums
        .Include(s => s.Courts)
        .Include(s => s.StadiumImages)
        .AsQueryable();
        }

    }
}
