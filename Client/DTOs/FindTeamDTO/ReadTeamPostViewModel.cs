using FindTeamAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FindTeamDTO
{
    public class ReadTeamPostViewModel
    {
        public List<ReadTeamPostDTO> TeamPosts { get; set; } = new List<ReadTeamPostDTO>();
        public Dictionary<int, int> Hidden { get; set; } = new Dictionary<int, int>();
    }
}
