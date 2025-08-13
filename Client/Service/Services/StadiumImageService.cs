using DTOs.StadiumDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StadiumImageService : IStadiumImageService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private string token = string.Empty;

        public StadiumImageService(HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            token = _tokenService.GetAccessTokenFromCookie();
        }
        public Task<ReadStadiumImageDTO> AddStadiumImageAsync(int stadiumId, CreateStadiumImageDTO createStadiumImageDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStadiumImageAsync(int stadiumId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReadStadiumImageDTO>> GetStadiumImagesAsync(int stadiumId)
        {
            throw new NotImplementedException();
        }

        public Task<ReadStadiumImageDTO> UpdateStadiumImageAsync(int stadiumId, UpdateStadiumImageDTO updateStadiumImageDTO)
        {
            throw new NotImplementedException();
        }
    }
}
