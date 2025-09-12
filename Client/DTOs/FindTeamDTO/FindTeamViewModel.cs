using DTOs.StadiumDTO;
using DTOs.UserDTO;
using FindTeamAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FindTeamDTO
{
    public class FindTeamViewModel
    {
        public List<ReadTeamPostDTO> TeamPosts { get; set; } = new List<ReadTeamPostDTO>();
        public Dictionary<int, ReadStadiumDTO> Stadiums { get; set; } = new Dictionary<int, ReadStadiumDTO>();
        public Dictionary<int, PublicUserProfileDTO> UserNames { get; set; } = new Dictionary<int, PublicUserProfileDTO>();
    }
}
