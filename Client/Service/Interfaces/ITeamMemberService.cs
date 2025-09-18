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
        Task<IEnumerable<ReadTeamMemberDTO>> GetAllTeamMemberByPostId(int postId);
        Task<ReadTeamMemberDTO> GetTeamMemberById(int postId, int teamId);
        Task<ReadTeamMemberDTO> AddTeamMember(CreateTeamMemberDTO createTeamMemberDTO);
        Task<ReadTeamMemberDTO> UpdateTeamMember(UpdateTeamMemberDTO updateTeamMemberDTO);
        Task<bool> DeleteTeamMember(int teamId, int postId);
    }
}
