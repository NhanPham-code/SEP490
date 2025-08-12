using StadiumAPI.DTOs;
using StadiumAPI.Models;

namespace StadiumAPI.Service.Interface
{
    public interface IServiceStadium
    {
        public Task<IEnumerable<ReadStadiumDTO>> GetAllStadiumsAsync();
        public Task<ReadStadiumDTO> GetStadiumByIdAsync(int id);
        public Task<ReadStadiumDTO> CreateStadiumAsync(CreateStadiumDTO createStadiumDTO);
        public Task<ReadStadiumDTO> UpdateStadiumAsync(int id, UpdateStadiumDTO updateStadiumDTO);
        public Task<bool> DeleteStadiumAsync(int id);
        public IQueryable<Stadiums> GetAllOdataStadiums();

    }
}
