using DTOs.StadiumDTO;
using Org.BouncyCastle.Asn1.Ocsp;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StadiumService : IStadiumService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private string token = string.Empty;


        public StadiumService(HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            token = _tokenService.GetAccessTokenFromCookie();
        }

        public void AddBearerAccessToken()
        {
            
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public Task<ReadStadiumDTO> CreateStadiumAsync(CreateStadiumDTO stadiumDto)
        {

            throw new NotImplementedException();
        }

        public Task<bool> DeleteStadiumAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReadStadiumDTO>> GetAllStadiumsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReadStadiumDTO> GetStadiumByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> SearchStadiumAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<ReadStadiumDTO> UpdateStadiumAsync(int id, UpdateStadiumDTO stadiumDto)
        {
            throw new NotImplementedException();
        }
    }
}
