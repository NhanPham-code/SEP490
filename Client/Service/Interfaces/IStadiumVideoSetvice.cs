using DTOs.StadiumDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IStadiumVideoSetvice
    {
        Task<IEnumerable<ReadStadiumVideoDTO>> GetAllVideoByStadiumId(int stadiumId);

        Task<IEnumerable<ReadStadiumVideoDTO>> AddStadiumVideoAsync(List<CreateStadiumVideoDTO> stadiumVideoDTO);

        Task<bool> DeleteStadiumVideoAsync(int[] id);

        Task<ReadStadiumVideoDTO> GetStadiumVideoByIdAsync(int id);

        Task<ReadStadiumVideoDTO> UpdateStadiumVideoAsync(int id, CreateStadiumVideoDTO stadiumVideoDTO);

        Task<bool> DeleteAllVideosByStadiumId(int stadiumId);
    }
}