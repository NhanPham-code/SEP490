using StadiumAPI.DTOs;

namespace StadiumAPI.Service.Interface
{
    public interface IStadiumVideosService
    {
        // Define methods for managing stadium Videos, e.g.:
        Task<IEnumerable<ReadStadiumVideoDTO>> GetAllVideosAsync(int stadiumId);

        Task<ReadStadiumVideoDTO> GetVideoByIdAsync(int id);

        Task<ReadStadiumVideoDTO> AddVideoAsync(CreateStadiumVideoDTO video, string videoUrl);

        Task<ReadStadiumVideoDTO> UpdateVideoAsync(int id, UpdateStadiumVideoDTO video, string videoUrl);

        Task<bool> DeleteVideoAsync(List<ReadStadiumVideoDTO> readStadiumVideoDTOs);

        Task<bool> DeleteVideoByStadiumIdAsync(int stadiumId);
    }
}