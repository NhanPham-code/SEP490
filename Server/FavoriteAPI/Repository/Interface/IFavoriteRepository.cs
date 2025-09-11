using FavoriteAPI.Model;

namespace FavoriteAPI.Repository.Interface
{
    public interface IFavoriteRepository
    {
        IQueryable<Favorite> GetFavorites();
        Task<Favorite> AddFavoriteAsync(Model.Favorite favorite);
        Task<bool> DeleteFavoriteAsync(int favoriteId);
        Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId);
        Task<Favorite?> GetFavoriteByIdAsync(int favoriteId);
    }
}
