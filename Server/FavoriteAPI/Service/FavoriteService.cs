using FavoriteAPI.DTOs;
using FavoriteAPI.Model;
using FavoriteAPI.Repository.Interface;
using FavoriteAPI.Service.Interface;

namespace FavoriteAPI.Service
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository ?? throw new ArgumentNullException(nameof(favoriteRepository));
        }

        public Task<Favorite> AddFavoriteAsync(CreateFavoriteDTO createFavoriteDTO)
        {
            // map CreateFavoriteDTO to Favorite model
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFavoriteAsync(int favoriteId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Favorite> GetFavorites()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId)
        {
            throw new NotImplementedException();
        }
    }
}
