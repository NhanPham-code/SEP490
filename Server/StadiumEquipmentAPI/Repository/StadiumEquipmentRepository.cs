using Microsoft.EntityFrameworkCore;
using StadiumEquipmentAPI.Data;
using StadiumEquipmentAPI.Models;

namespace StadiumEquipmentAPI.Repository
{
    public class StadiumEquipmentRepository : IStadiumEquipmentRepository
    {
        private readonly StadiumEquipmentDbContext _context;

        public StadiumEquipmentRepository(StadiumEquipmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StadiumEquipments>> GetAllAsync()
        {
            return await _context.StadiumEquipments.ToListAsync();
        }

        public async Task<StadiumEquipments?> GetByIdAsync(int id)
        {
            return await _context.StadiumEquipments.FindAsync(id);
        }

        public async Task<IEnumerable<StadiumEquipments>> GetByStadiumIdAsync(int stadiumId)
        {
            return await _context.StadiumEquipments
                .Where(e => e.StadiumId == stadiumId)
                .ToListAsync();
        }

        public async Task<StadiumEquipments> CreateAsync(StadiumEquipments equipment)
        {
            equipment.CreatedAt = DateTime.UtcNow;
            equipment.UpdatedAt = DateTime.UtcNow;

            _context.StadiumEquipments.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }

        public async Task<StadiumEquipments?> UpdateAsync(int id, StadiumEquipments equipment)
        {
            var existingEquipment = await _context.StadiumEquipments.FindAsync(id);
            if (existingEquipment == null)
                return null;

            existingEquipment.Name = equipment.Name;
            existingEquipment.Description = equipment.Description;
            existingEquipment.QuantityTotal = equipment.QuantityTotal;
            existingEquipment.QuantityAvailable = equipment.QuantityAvailable;
            existingEquipment.Status = equipment.Status;
            existingEquipment.ImagePath = equipment.ImagePath;
            existingEquipment.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingEquipment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var equipment = await _context.StadiumEquipments.FindAsync(id);
            if (equipment == null)
                return false;

            _context.StadiumEquipments.Remove(equipment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.StadiumEquipments.AnyAsync(e => e.Id == id);
        }
    }
}