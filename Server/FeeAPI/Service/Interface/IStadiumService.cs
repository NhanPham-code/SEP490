using DTOs;

namespace FeeAPI.Service.Interface
{
    public interface IStadiumService
    {
        Task<IEnumerable<OdataHaveCountResponse<ReadStadiumDTO>>> GetReadStadiumDTOsAsync();
    }
}
