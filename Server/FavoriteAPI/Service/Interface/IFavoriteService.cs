using FavoriteAPI.DTOs;
using FavoriteAPI.Model;

namespace FavoriteAPI.Service.Interface
{
    public interface IFavoriteService
    {
        IQueryable<Model.Favorite> GetFavorites();
        Task<Model.Favorite?> GetFavoritesByIdAsync(int userId, int stadiumId);
        Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int userId);
        Task<Model.Favorite> AddFavoriteAsync(CreateFavoriteDTO createFavoriteDTO);
        Task<bool> DeleteFavoriteAsync(int userId, int stadiumId);
        Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId);
    }
}
