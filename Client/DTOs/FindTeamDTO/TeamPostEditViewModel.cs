using DTOs.UserDTO;
using FindTeamAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FindTeamDTO
{
    public class TeamPostEditViewModel
    {
        public ReadTeamPostDTO? TeamPost { get; set; } = new ReadTeamPostDTO();
        public PrivateUserProfileDTO? User { get; set; } = new PrivateUserProfileDTO();
    }
}
