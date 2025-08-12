using AutoMapper;
using AutoMapper.QueryableExtensions;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;
using StadiumAPI.Service.Interface;
using System.Threading.Tasks;

namespace StadiumAPI.Service
{
    public class ServiceStadium : IServiceStadium
    {
        private readonly IStadiumRepositories _stadiumRepositories;
        private readonly IMapper _mapper;
        public ServiceStadium(IStadiumRepositories stadiumRepositories, IMapper mapper)
        {
            _stadiumRepositories = stadiumRepositories ?? throw new ArgumentNullException(nameof(stadiumRepositories));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ReadStadiumDTO>> GetAllStadiumsAsync()
        {
            var stadiums = await _stadiumRepositories.GetAllStadiumsAsync();
            return _mapper.Map<IEnumerable<ReadStadiumDTO>>(stadiums);
        }
        public async Task<ReadStadiumDTO> GetStadiumByIdAsync(int id)
        {
            var stadium = await _stadiumRepositories.GetStadiumByIdAsync(id);
            return _mapper.Map<ReadStadiumDTO>(stadium);
        }
        public async Task<ReadStadiumDTO> CreateStadiumAsync(CreateStadiumDTO createStadiumDTO)
        {
            var stadium = _mapper.Map<Stadiums>(createStadiumDTO);
            var createdStadium = await _stadiumRepositories.CreateStadiumAsync(stadium);
            return _mapper.Map<ReadStadiumDTO>(createdStadium);
        }
        public async Task<ReadStadiumDTO> UpdateStadiumAsync(int id, UpdateStadiumDTO updateStadiumDTO)
        {
            var stadium = _mapper.Map<Stadiums>(updateStadiumDTO);
            var updatedStadium = await _stadiumRepositories.UpdateStadiumAsync(id, stadium);
            return _mapper.Map<ReadStadiumDTO>(updatedStadium);
        }
        public async Task<bool> DeleteStadiumAsync(int id)
        {
            return await _stadiumRepositories.DeleteStadiumAsync(id);
        }
        public IQueryable<Stadiums> GetAllOdataStadiums()
        {
            return _stadiumRepositories.GetOdataStadiums();
        }

    }
}
