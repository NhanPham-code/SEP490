using StadiumAPI.DTOs;
using StadiumAPI.Models;

namespace StadiumAPI.Repositories.Interface
{
    public interface IStadiumVideosRepositories
    {
        // Define methods for managing stadium images, e.g.:
        Task<IEnumerable<StadiumVideos>> GetAllStadiumVideoByStadiumId(int stadiumId);

        Task<StadiumVideos> GetVideoByIdAsync(int id);

        Task<StadiumVideos> AddVideoAsync(StadiumVideos image);

        Task<StadiumVideos> UpdateVideoAsync(int id, StadiumVideos image);

        Task<bool> DeleteVideoAsync(List<StadiumVideos> stadiumVideos);

        Task<bool> DeleteVIdeoByStadiumIdAsync(int stadiumId);
    }
}