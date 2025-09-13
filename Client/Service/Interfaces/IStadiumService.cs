using DTOs.OData;
using DTOs.StadiumDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IStadiumService
    {
        Task<string> GetAllStadiumsAsync();
        Task<OdataHaveCountResponse<ReadStadiumDTO>> GetAllStadiumByListId(List<int> stadiumId);
        Task<ReadStadiumDTO> GetStadiumByIdAsync(int id);
        Task<ReadStadiumDTO> CreateStadiumAsync(CreateStadiumDTO stadiumDto);
        Task<ReadStadiumDTO> UpdateStadiumAsync(int id, UpdateStadiumDTO stadiumDto);
        Task<bool> DeleteStadiumAsync(int id);
        Task<string> SearchStadiumAsync(string searchTerm); 
    }
}
