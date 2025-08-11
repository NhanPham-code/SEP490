using StadiumAPI.DTOs;
using StadiumAPI.Models;

namespace StadiumAPI.Repositories.Interface
{
    public interface IStadiumRepositories
    {
        public Task<IEnumerable<Stadiums>> GetAllStadiumsAsync();
        public Task<Stadiums> GetStadiumByIdAsync(int id);
        public Task<Stadiums> CreateStadiumAsync(Stadiums stadiums);
        public Task<Stadiums> UpdateStadiumAsync(int id, Stadiums stadiums);
        public Task<bool> DeleteStadiumAsync(int id);
        public IQueryable<Stadiums> GetOdataStadiums();

    }
}
