using AutoMapper;
using FindTeamAPI.DTOs;
using FindTeamAPI.Models;

namespace FindTeamAPI.Mapper
{
    public class FindTeamProfile : Profile
    {
        public FindTeamProfile() { 
        
            CreateMap<TeamMember, ReadTeamMemberDTO>();
            CreateMap<TeamPost, ReadTeamPostDTO>();
            CreateMap<TeamMember, CreateTeamMemberDTO>();
            CreateMap<TeamPost, CreateTeamPostDTO>();
            CreateMap<TeamMember, UpdateTeamMemberDTO>();
            CreateMap<TeamPost, UpdateTeamPostDTO>();
            CreateMap<CreateTeamMemberDTO, TeamMember>();
            CreateMap<CreateTeamPostDTO, TeamPost>();
            CreateMap<UpdateTeamMemberDTO, TeamMember>();
            CreateMap<UpdateTeamPostDTO, TeamPost>();
            CreateMap<ReadTeamMemberDTO, TeamMember>();
            CreateMap<ReadTeamPostDTO, TeamPost>();

        }
    }
}
