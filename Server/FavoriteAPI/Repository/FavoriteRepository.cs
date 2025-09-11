using FavoriteAPI.Data;
using FavoriteAPI.Model;
using FavoriteAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FavoriteAPI.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly FavoriteDbContext _context;

        public FavoriteRepository(FavoriteDbContext context)
        {
            _context = context;
        }

        public async Task<Favorite> AddFavoriteAsync(Favorite favorite)
        {
           // add new favorite
           _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
            return favorite;
        }

        public async Task<bool> DeleteFavoriteAsync(int favoriteId)
        {
            // delete favorite by id
            var favorite = await _context.Favorites.FindAsync(favoriteId);
            if (favorite == null)
            {
                return false;
            }
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Favorite> GetFavorites()
        {
            return _context.Favorites.AsQueryable();
        }

        public Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId)
        {
            // check if favorite exists by userId and stadiumId
            return _context.Favorites.AnyAsync(f => f.UserId == userId && f.StadiumId == stadiumId);
        }
    }
}
