using StadiumEquipmentAPI.DTOs;

namespace StadiumEquipmentAPI.Service
{
    public interface IStadiumEquipmentService
    {
        Task<IEnumerable<StadiumEquipmentResponse>> GetAllEquipmentsAsync();
        Task<StadiumEquipmentResponse?> GetEquipmentByIdAsync(int id);
        Task<IEnumerable<StadiumEquipmentResponse>> GetEquipmentsByStadiumIdAsync(int stadiumId);
        Task<StadiumEquipmentResponse> CreateEquipmentAsync(CreateStadiumEquipment createDto);
        Task<StadiumEquipmentResponse?> UpdateEquipmentAsync(int id, UpdateStadiumEquipment updateDto);
        Task<bool> DeleteEquipmentAsync(int id);
    }
}