using AutoMapper;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;
using StadiumAPI.Service.Interface;

namespace StadiumAPI.Service
{
    public class CourtsService : ICourtsService
    {
        private readonly ICourtsRepositories _courtsRepositories;
        private readonly IMapper _mapper;

        public CourtsService(ICourtsRepositories courtsRepositories, IMapper mapper)
        {
            _courtsRepositories = courtsRepositories ?? throw new ArgumentNullException(nameof(courtsRepositories));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ReadCourtDTO> CreateCourtAsync(CreateCourtDTO createCourtDTO)
        {
            if (createCourtDTO == null)
                throw new ArgumentNullException(nameof(createCourtDTO));

            var court = _mapper.Map<Courts>(createCourtDTO);
            var createdCourt = await _courtsRepositories.CreateCourtAsync(court);
            return _mapper.Map<ReadCourtDTO>(createdCourt);
        }

        public Task<bool> DeleteCourtAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");

            return _courtsRepositories.DeleteCourtAsync(id);
        }

        public async Task<IEnumerable<ReadCourtDTO>> GetAllCourtsAsync(int stadiumId)
        {
            if (stadiumId <= 0)
                throw new ArgumentOutOfRangeException(nameof(stadiumId), "Stadium ID must be greater than zero.");

            var courts = await _courtsRepositories.GetAllCourtsAsync(stadiumId);
            return _mapper.Map<IEnumerable<ReadCourtDTO>>(courts);
        }

        public async Task<ReadCourtDTO> GetCourtAndCourtRelation(int stadiumId)
        {
            var courts = await _courtsRepositories.GetCourtAndCourtRelation(stadiumId);
            return _mapper.Map<ReadCourtDTO>(courts);
        }

        public async Task<ReadCourtDTO> GetCourtByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");

            var court = await _courtsRepositories.GetCourtByIdAsync(id);
            return _mapper.Map<ReadCourtDTO>(court);
        }

        public async Task<ReadCourtDTO> UpdateCourtAsync(int id, UpdateCourtDTO updateCourtDTO)
        {
            if (updateCourtDTO == null)
                throw new ArgumentNullException(nameof(updateCourtDTO));
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");

            var court = _mapper.Map<Courts>(updateCourtDTO);
            var updatedCourt = await _courtsRepositories.UpdateCourtAsync(id, court);
            return _mapper.Map<ReadCourtDTO>(updatedCourt);
        }
    }
}
