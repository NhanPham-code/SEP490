using Microsoft.EntityFrameworkCore;
using StadiumAPI.Data;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;

public class CourtsRepositories : ICourtsRepositories
{
    private readonly StadiumDbContext _context;
    public CourtsRepositories(StadiumDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Courts> CreateCourtAsync(Courts court)
    {
        if (court == null)
            throw new ArgumentNullException(nameof(court));

        _context.Courts.Add(court);
        await _context.SaveChangesAsync();
        return court;
    }

    public async Task<bool> DeleteCourtAsync(int id)
    {
        var court = await _context.Courts.FindAsync(id);
        if (court == null) return false;

        _context.Courts.Remove(court);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Courts>> GetAllCourtsAsync(int stadiumId)
    {
        if (stadiumId <= 0)
            throw new ArgumentOutOfRangeException(nameof(stadiumId), "Stadium ID must be greater than zero.");

        return await _context.Courts
            .Where(c => c.StadiumId == stadiumId)
            .ToListAsync();
    }

    public async Task<Courts> GetCourtAndCourtRelation(int stadiumId)
    {
        var court = await _context.Courts
         .Include(c => c.ChildRelations)
             .ThenInclude(cr => cr.ChildCourt)
         .Include(c => c.ParentRelations)
             .ThenInclude(cr => cr.ParentCourt)
         .FirstOrDefaultAsync(c => c.StadiumId == stadiumId);

        if (court == null)
        {
            throw new KeyNotFoundException($"Court in Stadium {stadiumId} not found.");
        }

        return court;
    }

    public async Task<Courts> GetCourtByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");

        return await _context.Courts.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Courts> UpdateCourtAsync(int id, Courts court)
    {
        if (court == null)
            throw new ArgumentNullException(nameof(court));

        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");

        var existingCourt = await _context.Courts.FindAsync(id);
        if (existingCourt == null)
            throw new KeyNotFoundException($"Court with ID {id} not found.");

        existingCourt.Name = court.Name;
        existingCourt.SportType = court.SportType;
        existingCourt.PricePerHour = court.PricePerHour;
        existingCourt.IsAvailable = court.IsAvailable;
        existingCourt.UpdatedAt = DateTime.UtcNow;

        _context.Courts.Update(existingCourt);
        await _context.SaveChangesAsync();

        return existingCourt;
    }
}
