using DTOs.UserDTO;
using FindTeamAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FindTeamDTO
{
    public class MemberViewModel
    {
        public List<ReadTeamMemberDTO> TeamMembers { get; set; } = new List<ReadTeamMemberDTO>();
        public Dictionary<int, PublicUserProfileDTO> Users { get; set; } = new Dictionary<int, PublicUserProfileDTO>();
        public int LeaderId { get; set; }
    }
}
