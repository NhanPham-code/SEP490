using StadiumAPI.Models;

namespace StadiumAPI.Repositories.Interface
{
    public interface ICourtsRepositories
    {
        Task<IEnumerable<Courts>> GetAllCourtsAsync(int stadiumId);
        Task<Courts> GetCourtByIdAsync(int id);
        Task<Courts> CreateCourtAsync(Courts court);
        Task<Courts> UpdateCourtAsync(int id, Courts court);
        Task<bool> DeleteCourtAsync(int id);
    }
}
