using AutoMapper;
using UserAPI.DTOs;
using UserAPI.Model;

namespace UserAPI.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            //CreateMap<User, UserValidateResultDTO>();

            CreateMap<User, PrivateUserProfileDTO>();

            CreateMap<User, PublicUserProfileDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.AvatarUrl));

            CreateMap<CustomerRegisterRequestDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

            CreateMap<UpdateUserProfileDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        }
    }
}
