using FavoriteAPI.Model;

namespace FavoriteAPI.Repository.Interface
{
    public interface IFavoriteRepository
    {
        IQueryable<Favorite> GetFavorites();
        Task<Favorite> AddFavoriteAsync(Model.Favorite favorite);
        Task<bool> DeleteFavoriteAsync(int userId, int stadiumId);
        Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId);
        Task<Favorite?> GetFavoriteByIdAsync(int userId, int stadiumId);
        Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int userId);
        Task<IEnumerable<Favorite>> GetFavoritesByStadiumIdAsync(int stadiumId);
    }
}
