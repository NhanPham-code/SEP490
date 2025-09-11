using FindTeamAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITeamMemberService
    {
        Task<ReadTeamMemberDTO> GetAllTeamMemberByPostId(int postId);
        Task<ReadTeamMemberDTO> GetTeamMmeberById();
        Task<ReadTeamMemberDTO> AddTeamMember(CreateTeamMemberDTO createTeamMemberDTO);
        Task<ReadTeamMemberDTO> UpdateTeamMember(UpdateTeamMemberDTO updateTeamMemberDTO);
        Task DeleteTeamMember(int teamId, int postId);
    }
}
