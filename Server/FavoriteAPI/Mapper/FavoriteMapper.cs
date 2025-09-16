using AutoMapper;

namespace FavoriteAPI.Mapper
{
    public class FavoriteMapper : Profile
    {
        public FavoriteMapper()
        {
            CreateMap<DTOs.CreateFavoriteDTO, Model.Favorite>();
        }
    }
}
