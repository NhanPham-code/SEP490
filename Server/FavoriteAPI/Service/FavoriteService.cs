using AutoMapper;
using FavoriteAPI.DTOs;
using FavoriteAPI.Model;
using FavoriteAPI.Repository.Interface;
using FavoriteAPI.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace FavoriteAPI.Service
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IMapper _mapper;

        public FavoriteService(IFavoriteRepository favoriteRepository, IMapper mapper)
        {
            _favoriteRepository = favoriteRepository ?? throw new ArgumentNullException(nameof(favoriteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Favorite> AddFavoriteAsync(CreateFavoriteDTO createFavoriteDTO)
        {
            // map CreateFavoriteDTO to Favorite model
            var favorite = _mapper.Map<Favorite>(createFavoriteDTO);
            return  await _favoriteRepository.AddFavoriteAsync(favorite);
        }

        public async Task<bool> DeleteFavoriteAsync(int userId, int stadiumId)
        {
            return await _favoriteRepository.DeleteFavoriteAsync(userId, stadiumId);
        }

        public IQueryable<Favorite> GetFavorites()
        {
            return _favoriteRepository.GetFavorites();
        }

        public async Task<Favorite?> GetFavoritesByIdAsync(int userId, int stadiumId)
        {
            var favorite = await _favoriteRepository.GetFavoriteByIdAsync(userId, stadiumId);
            if (favorite == null)
            {
                return null;
            }
            return favorite;
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int userId)
        {
            return await _favoriteRepository.GetFavoritesByUserIdAsync(userId);
        }

        public async Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId)
        {
           // check if favorite exists by userId and stadiumId
           return await _favoriteRepository.IsFavoriteExistsAsync(userId, stadiumId);
        }
        public async Task<IEnumerable<Favorite>> GetFavoritesByStadiumIdAsync(int stadiumId)
        {
            return await _favoriteRepository.GetFavoritesByStadiumIdAsync(stadiumId);
        }
    }
}
