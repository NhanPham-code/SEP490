using StadiumEquipmentAPI.Models;

namespace StadiumEquipmentAPI.Repository
{
    public interface IStadiumEquipmentRepository
    {
        Task<IEnumerable<StadiumEquipments>> GetAllAsync();
        Task<StadiumEquipments?> GetByIdAsync(int id);
        Task<IEnumerable<StadiumEquipments>> GetByStadiumIdAsync(int stadiumId);
        Task<StadiumEquipments> CreateAsync(StadiumEquipments equipment);
        Task<StadiumEquipments?> UpdateAsync(int id, StadiumEquipments equipment);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}