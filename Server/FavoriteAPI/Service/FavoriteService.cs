using AutoMapper;
using FavoriteAPI.DTOs;
using FavoriteAPI.Model;
using FavoriteAPI.Repository.Interface;
using FavoriteAPI.Service.Interface;

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

        public async Task<bool> DeleteFavoriteAsync(int favoriteId)
        {
            // check if favorite exists
            var existingFavorite = await _favoriteRepository.GetFavoriteByIdAsync(favoriteId);
            if (existingFavorite == null)
            {
                return false;
            }
            return await _favoriteRepository.DeleteFavoriteAsync(favoriteId);
        }

        public IQueryable<Favorite> GetFavorites()
        {
            return _favoriteRepository.GetFavorites();
        }

        public async Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId)
        {
           // check if favorite exists by userId and stadiumId
           return await _favoriteRepository.IsFavoriteExistsAsync(userId, stadiumId);
        }
    }
}
