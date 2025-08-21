using StadiumAPI.Models;

namespace StadiumAPI.Repositories.Interface
{
    public interface ICourtsRepositories
    {
        public Task<IEnumerable<Courts>> GetAllCourtsAsync(int stadiumId);
        public Task<Courts> GetCourtByIdAsync(int id);
        public Task<Courts> CreateCourtAsync(Courts court);
        public Task<Courts> UpdateCourtAsync(int id, Courts court);
        public Task<bool> DeleteCourtAsync(int id);
        public Task<Courts> GetCourtAndCourtRelation(int stadiumId);
    }
}
