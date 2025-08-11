using StadiumAPI.DTOs;

namespace StadiumAPI.Service.Interface
{
    public interface IStadiumImagesService
    {
        // Define methods for managing stadium images, e.g.:
        Task<IEnumerable<ReadStadiumImageDTO>> GetAllImagesAsync(int stadiumId);
        Task<ReadStadiumImageDTO> GetImageByIdAsync(int id);
        Task<ReadStadiumImageDTO> AddImageAsync(CreateStadiumImageDTO image, string imgUrl);
        Task<ReadStadiumImageDTO> UpdateImageAsync(int id, UpdateStadiumImageDTO image, string imageUrl);
        Task<bool> DeleteImageAsync(int id);
    }
}
