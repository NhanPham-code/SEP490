using DTOs.UserDTO;
using FindTeamAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FindTeamDTO
{
    public class TeamPostDetailViewModel
    {
        public ReadTeamPostDTO? TeamPost { get; set; } = new ReadTeamPostDTO();
        public PublicUserProfileDTO? User { get; set; } = new PublicUserProfileDTO();
        public int newMember { get; set; }
        public int isLeader { get; set; }
        public ReadTeamMemberDTO? memberDTO { get; set; } = new ReadTeamMemberDTO();
    }
}
