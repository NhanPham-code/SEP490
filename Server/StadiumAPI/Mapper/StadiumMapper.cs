using AutoMapper;
using StadiumAPI.DTOs;
using StadiumAPI.Models;

namespace StadiumAPI.Mapper
{
    public class StadiumMapper : Profile
    {
        public StadiumMapper()
        {
            // Stadium Mappings
            CreateMap<Stadiums, ReadStadiumDTO>();

            CreateMap<CreateStadiumDTO, Stadiums>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateStadiumDTO, Stadiums>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()); // Ignore CreatedAt to keep the original value
            CreateMap<Stadiums, UpdateStadiumDTO>();

            // Court Mappings
            CreateMap<CreateCourtDTO, Courts>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateCourtDTO, Courts>();

            CreateMap<Courts, UpdateCourtDTO>();

            CreateMap<Courts, ReadCourtDTO>();

            CreateMap<ReadCourtDTO, Courts>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            // Stadium Image Mappings
            CreateMap<StadiumImages, ReadStadiumImageDTO>();

            CreateMap<ReadStadiumImageDTO, StadiumImages>();

            CreateMap<CreateStadiumImageDTO, StadiumImages>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore()); // nếu bạn xử lý upload ở service

            CreateMap<UpdateStadiumImageDTO, StadiumImages>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

            CreateMap<CourtRelations, ReadCourtRelationDTO>();
            CreateMap<ReadCourtRelationDTO, CourtRelations>();

            CreateMap<CreateCourtRelationDTO, CourtRelations>()
                .ForMember(dest => dest.ChildCourt, opt => opt.Ignore())
                .ForMember(dest => dest.ParentCourt, opt => opt.Ignore());
            CreateMap<UpdateCourtRelationDTO, CourtRelations>();

            CreateMap<StadiumVideos, ReadStadiumVideoDTO>();

            CreateMap<ReadStadiumVideoDTO, StadiumVideos>();
            CreateMap<CreateStadiumVideoDTO, StadiumVideos>()
                .ForMember(dest => dest.VideoUrl, opt => opt.Ignore()); // nếu bạn xử lý upload ở service
            CreateMap<UpdateStadiumVideoDTO, StadiumVideos>()
                .ForMember(dest => dest.VideoUrl, opt => opt.Ignore()); // nếu bạn xử lý upload ở service
        }
    }
}