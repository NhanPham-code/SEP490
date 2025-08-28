using StadiumAPI.DTOs;
using StadiumAPI.Models;

namespace StadiumAPI.Repositories.Interface
{
    public interface IStadiumImagesRepositories
    {
        // Define methods for managing stadium images, e.g.:
        Task<IEnumerable<StadiumImages>> GetAllImagesAsync(int stadiumId);

        Task<StadiumImages> GetImageByIdAsync(int id);

        Task<StadiumImages> AddImageAsync(StadiumImages image);

        Task<StadiumImages> UpdateImageAsync(int id, StadiumImages image);

        Task<bool> DeleteImageAsync(int id);
    }
}