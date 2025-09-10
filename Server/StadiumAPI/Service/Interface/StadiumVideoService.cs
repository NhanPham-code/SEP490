using AutoMapper;
using StadiumAPI.DTOs;
using StadiumAPI.Repositories.Interface;
using StadiumAPI.Models;

namespace StadiumAPI.Service.Interface
{
    public class StadiumVideoService : IStadiumVideosService
    {
        private readonly IStadiumVideosRepositories _stadiumVideosRepositories;
        private readonly IMapper _mapper;

        public StadiumVideoService(IStadiumVideosRepositories stadiumVideosRepositories, IMapper mapper)
        {
            _stadiumVideosRepositories = stadiumVideosRepositories;
            _mapper = mapper;
        }

        public async Task<ReadStadiumVideoDTO> AddVideoAsync(CreateStadiumVideoDTO video, string videoUrl)
        {
            var stadiumVideo = _mapper.Map<StadiumVideos>(video);
            stadiumVideo.VideoUrl = videoUrl;
            var addedVideo = await _stadiumVideosRepositories.AddVideoAsync(stadiumVideo);
            return _mapper.Map<ReadStadiumVideoDTO>(addedVideo);
        }

        public async Task<bool> DeleteVideoAsync(List<ReadStadiumVideoDTO> readStadiumVideoDTOs)
        {
            var stadiumVideos = _mapper.Map<List<StadiumVideos>>(readStadiumVideoDTOs);
            return await _stadiumVideosRepositories.DeleteVideoAsync(stadiumVideos);
        }

        public async Task<bool> DeleteVideoByStadiumIdAsync(int stadiumId)
        {
            var result = await _stadiumVideosRepositories.DeleteVIdeoByStadiumIdAsync(stadiumId);
            return result;
        }

        public async Task<IEnumerable<ReadStadiumVideoDTO>> GetAllVideosAsync(int stadiumId)
        {
            var videos = await _stadiumVideosRepositories.GetAllStadiumVideoByStadiumId(stadiumId);
            return _mapper.Map<IEnumerable<ReadStadiumVideoDTO>>(videos);
        }

        public async Task<ReadStadiumVideoDTO> GetVideoByIdAsync(int id)
        {
            var video = await _stadiumVideosRepositories.GetVideoByIdAsync(id);
            return _mapper.Map<ReadStadiumVideoDTO>(video);
        }

        public async Task<ReadStadiumVideoDTO> UpdateVideoAsync(int id, UpdateStadiumVideoDTO video, string videoUrl)
        {
            var stadiumVideo = _mapper.Map<StadiumVideos>(video);
            var updatedVideo = await _stadiumVideosRepositories.UpdateVideoAsync(id, stadiumVideo);
            return _mapper.Map<ReadStadiumVideoDTO>(updatedVideo);
        }
    }
}