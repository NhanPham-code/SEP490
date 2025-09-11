using FavoriteAPI.DTOs;

namespace FavoriteAPI.Service.Interface
{
    public interface IFavoriteService
    {
        IQueryable<Model.Favorite> GetFavorites();
        Task<Model.Favorite> AddFavoriteAsync(CreateFavoriteDTO createFavoriteDTO);
        Task<bool> DeleteFavoriteAsync(int favoriteId);
        Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId);
    }
}
