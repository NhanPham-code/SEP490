using DTOs.FindTeamDTO;
using DTOs.OData;
using FindTeamAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITeamPostService
    {
        Task<OdataHaveCountResponse<ReadTeamPostDTO>> GetOdataTeamPostAsync(string url);
        Task<ReadTeamPostDTO> CreateTeamPost(CreateTeamPostDTO createTeamPostDTO);
        Task<ReadTeamPostDTO> UpdateTeamPost(UpdateTeamPostDTO updateTeamPostDTO);
        Task<bool> DeleteTeamPost(int postId);
    }
}
