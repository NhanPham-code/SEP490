    using System.Threading.Tasks;
    using StadiumAPI.DTOs;

    namespace StadiumAPI.Services
    {
        public interface IFirebaseService
        {
            Task AddStadiumAsync(ReadStadiumDTO stadium);
            Task DeleteStadiumAsync(int stadiumId);

            Task UpdateStadiumLockStatusAsync(int stadiumId, bool isLocked);
    }
    }
