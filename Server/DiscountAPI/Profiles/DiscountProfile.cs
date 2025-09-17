using AutoMapper;
using DiscountAPI.DTO;
using Models;
using System.Linq;

namespace DiscountAPI.Profiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            // Entity → DTO
            CreateMap<Discount, ReadDiscountDTO>()
                .ForMember(dest => dest.StadiumIds,
                           opt => opt.MapFrom(src => src.DiscountStadiums.Select(ds => ds.StadiumId).ToList()));

            // DTO (create) → Entity
            CreateMap<CreateDiscountDTO, Discount>()
                .ForMember(dest => dest.DiscountStadiums,
                           opt => opt.MapFrom(src => src.StadiumIds != null
                               ? src.StadiumIds.Select(id => new DiscountStadium { StadiumId = id }).ToList()
                               : new List<DiscountStadium>()));

            // DTO (update) → Entity
            CreateMap<UpdateDiscountDTO, Discount>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // giữ nguyên Id trong entity
                .ForMember(dest => dest.DiscountStadiums,
                           opt => opt.MapFrom(src => src.StadiumIds != null
                               ? src.StadiumIds.Select(id => new DiscountStadium { StadiumId = id }).ToList()
                               : new List<DiscountStadium>()))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
