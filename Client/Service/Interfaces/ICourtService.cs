using DTOs.StadiumDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICourtService
    {
        Task<IEnumerable<ReadCourtDTO>> GetAllCourtsAsync();
        Task<ReadCourtDTO> GetCourtByIdAsync(int id);
        Task<ReadCourtDTO> CreateCourtAsync(CreateCourtDTO courtDto);
        Task<ReadCourtDTO> UpdateCourtAsync(int id, UpdateCourtDTO courtDto);
        Task<bool> DeleteCourtAsync(int id);
    }
}
