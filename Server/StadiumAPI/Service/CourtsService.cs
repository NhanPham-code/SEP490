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

        public Task<ReadCourtDTO> CreateCourtAsync(CreateCourtDTO createCourtDTO)
        {
            if (createCourtDTO == null)
            {
                throw new ArgumentNullException(nameof(createCourtDTO));
            }
            var court = _mapper.Map<Courts>(createCourtDTO);
            return _courtsRepositories.CreateCourtAsync(court)
                .ContinueWith(task => _mapper.Map<ReadCourtDTO>(task.Result));
        }

        public Task<bool> DeleteCourtAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");
            }
            return _courtsRepositories.DeleteCourtAsync(id);
        }

        public Task<IEnumerable<ReadCourtDTO>> GetAllCourtsAsync(int stadiumId)
        {
            if (stadiumId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stadiumId), "Stadium ID must be greater than zero.");
            }
            return _courtsRepositories.GetAllCourtsAsync(stadiumId)
                .ContinueWith(task => _mapper.Map<IEnumerable<ReadCourtDTO>>(task.Result));
        }



        public Task<ReadCourtDTO> GetCourtByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");
            }
            return _courtsRepositories.GetCourtByIdAsync(id)
                .ContinueWith(task => _mapper.Map<ReadCourtDTO>(task.Result));
        }

        public Task<ReadCourtDTO> UpdateCourtAsync(int id, UpdateCourtDTO updateCourtDTO)
        {
            if (updateCourtDTO == null)
            {
                throw new ArgumentNullException(nameof(updateCourtDTO));
            }
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Court ID must be greater than zero.");
            }
            var court = _mapper.Map<Courts>(updateCourtDTO);
            return _courtsRepositories.UpdateCourtAsync(id, court)
                .ContinueWith(task => _mapper.Map<ReadCourtDTO>(task.Result));
        }
    }
}
