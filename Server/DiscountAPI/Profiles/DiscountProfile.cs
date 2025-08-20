using AutoMapper;
using DiscountAPI.DTO;
using Models;

namespace DiscountAPI.Profiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Discount, ReadDiscountDTO>();
            CreateMap<CreateDiscountDTO, Discount>();
            CreateMap<UpdateDiscountDTO, Discount>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Nếu không muốn map ID
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
