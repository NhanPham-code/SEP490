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

            CreateMap<User, PrivateUserProfileDTO>()
                .ForMember(dest => dest.AvatarUrl, opt => opt.NullSubstitute("/uploads/avatars/default-avatar.png"));

            CreateMap<User, PublicUserProfileDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.AvatarUrl, opt => opt.NullSubstitute("/uploads/avatars/default-avatar.png"));

            CreateMap<User, AdminUserProfileDTO>()
                .ForMember(dest => dest.AvatarUrl, opt =>
                opt.NullSubstitute("/uploads/avatars/default-avatar.png"));

            CreateMap<CustomerRegisterRequestDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

            CreateMap<UpdateUserProfileDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        }
    }
}
