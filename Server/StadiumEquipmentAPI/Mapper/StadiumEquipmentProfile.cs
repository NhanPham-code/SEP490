using AutoMapper;
using StadiumEquipmentAPI.DTOs;
using StadiumEquipmentAPI.Models;

namespace StadiumEquipmentAPI.Mapper
{
    public class StadiumEquipmentProfile : Profile
    {
        public StadiumEquipmentProfile()
        {
            CreateMap<StadiumEquipments, StadiumEquipmentResponse>();
            CreateMap<CreateStadiumEquipment, StadiumEquipments>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ?? "Active"));
            CreateMap<UpdateStadiumEquipment, StadiumEquipments>();
        }
    }
}
