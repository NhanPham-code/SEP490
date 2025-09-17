using AutoMapper;
using AutoMapper.QueryableExtensions;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;
using StadiumAPI.Service.Interface;
using StadiumAPI.Services;
using System.Threading.Tasks;

namespace StadiumAPI.Service
{
    public class ServiceStadium : IServiceStadium
    {
        private readonly IStadiumRepositories _stadiumRepositories;
        private readonly IMapper _mapper;
        private readonly IFirebaseService _firebaseService;
        public ServiceStadium(IStadiumRepositories stadiumRepositories, IMapper mapper, IFirebaseService firebaseService)
        {
            _stadiumRepositories = stadiumRepositories ?? throw new ArgumentNullException(nameof(stadiumRepositories));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _firebaseService = firebaseService ?? throw new ArgumentNullException(nameof(firebaseService));
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
            var dto = _mapper.Map<ReadStadiumDTO>(createdStadium);

            // 🔥 Sync Firebase
            if (dto != null)
            {
                await _firebaseService.AddStadiumAsync(dto);
            }

            return dto;
        }

        public async Task<ReadStadiumDTO> UpdateStadiumAsync(int id, UpdateStadiumDTO updateStadiumDTO)
        {
            var stadium = _mapper.Map<Stadiums>(updateStadiumDTO);
            var updatedStadium = await _stadiumRepositories.UpdateStadiumAsync(id, stadium);
            var dto = _mapper.Map<ReadStadiumDTO>(updatedStadium);

            // 🔥 Update Firebase
            if (dto != null)
            {
                await _firebaseService.AddStadiumAsync(dto);
            }

            return dto;
        }
        public async Task<bool> DeleteStadiumAsync(int id)
        {
            var deleted = await _stadiumRepositories.DeleteStadiumAsync(id);

            if (deleted)
            {
                // 🔥 Remove Firebase node
                await _firebaseService.DeleteStadiumAsync(id);
            }

            return deleted;
        }
        public IQueryable<Stadiums> GetAllOdataStadiums()
        {
            return _stadiumRepositories.GetOdataStadiums();
        }

    }
}