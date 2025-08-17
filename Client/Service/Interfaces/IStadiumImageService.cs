using DTOs.StadiumDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IStadiumImageService
    {
        Task<IEnumerable<ReadStadiumImageDTO>> GetStadiumImagesAsync(int stadiumId);
        Task<ReadStadiumImageDTO> AddStadiumImageAsync(int stadiumId, CreateStadiumImageDTO createStadiumImageDTO);
        Task<bool> DeleteStadiumImageAsync(int stadiumId);
        Task<ReadStadiumImageDTO> UpdateStadiumImageAsync(int stadiumId, UpdateStadiumImageDTO updateStadiumImageDTO);
    }
}
