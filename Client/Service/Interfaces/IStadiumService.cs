using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.StadiumDTO;

namespace Service.Interfaces
{
    public interface IStadiumService
    {
        Task<IEnumerable<ReadStadiumDTO>> GetAllStadiumsAsync();
        Task<ReadStadiumDTO> GetStadiumByIdAsync(int id);
        Task<ReadStadiumDTO> CreateStadiumAsync(CreateStadiumDTO stadiumDto);
        Task<ReadStadiumDTO> UpdateStadiumAsync(int id, UpdateStadiumDTO stadiumDto);
        Task<bool> DeleteStadiumAsync(int id);
        Task<string> SearchStadiumAsync(string searchTerm); 
    }
}
