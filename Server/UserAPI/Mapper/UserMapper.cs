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

            CreateMap<User, ReadUserDTO>();

            CreateMap<RegisterRequestDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

            CreateMap<UpdateUserProfileDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        }
    }
}
