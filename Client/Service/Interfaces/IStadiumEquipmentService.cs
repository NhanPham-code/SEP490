using DTOs.StadiumEquipmentDTO;

namespace Service.Interfaces
{
    public interface IStadiumEquipmentService
    {
        Task<IEnumerable<StadiumEquipmentResponse>> GetAllAsync(string accessToken);
        Task<StadiumEquipmentResponse?> GetByIdAsync(string accessToken, int id);
        Task<StadiumEquipmentResponse?> CreateAsync(CreateStadiumEquipment dto, string accessToken);
        Task<bool> UpdateAsync(string accessToken, int id, UpdateStadiumEquipment dto);
        Task<bool> DeleteAsync(string accessToken, int id);
        Task<IEnumerable<StadiumEquipmentResponse>> GetByStadiumIdAsync(int stadiumId);
        Task<(IEnumerable<StadiumEquipmentResponse> data, int totalCount)> GetByStadiumIdPagedAsync(int stadiumId, int page, int pageSize);
    }
}
