using DTOs.FeesDTO;
using DTOs.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFeesService
    {
        Task<IEnumerable<FeeDto>?> GetAllFeesAsync(string token);

        Task<FeeDto?> GetFeeByIdAsync(int id, string token);

        Task<IEnumerable<FeeDto>?> GetFeesByStadiumIdAsync(int stadiumId, string token);

        Task<IEnumerable<FeeDto>?> GetFeesByOwnerIdAsync(int ownerId, string token);

        Task<IEnumerable<FeeDto>?> GetFeesByMonthYearAsync(int month, int year, string token);

        Task<FeeDto> UpdateFeeToPaidAsync(int id, string token);

        Task<OdataHaveCountResponse<FeeDto>> GetFeesForOwner(string token, int ownerId, int month, int year);

        Task<FeeDto?> UploadBillImage(string token, UploadBillImageDTO uploadBillImageDTO);
    }
}
