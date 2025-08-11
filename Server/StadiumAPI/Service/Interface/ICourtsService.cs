using StadiumAPI.DTOs;
using StadiumAPI.Models;

namespace StadiumAPI.Service.Interface
{
    public interface ICourtsService
    {
        Task<IEnumerable<ReadCourtDTO>> GetAllCourtsAsync(int stadiumId);
        Task<ReadCourtDTO> GetCourtByIdAsync(int id);
        Task<ReadCourtDTO> CreateCourtAsync(CreateCourtDTO createCourtDTO);
        Task<ReadCourtDTO> UpdateCourtAsync(int id, UpdateCourtDTO updateCourtDTO);
        Task<bool> DeleteCourtAsync(int id);
        //IQueryable<Courts> GetAllOdataCourts(int stadiumId);
    }
}
