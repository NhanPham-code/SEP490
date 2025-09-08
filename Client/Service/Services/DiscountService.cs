using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs.DiscountDTO;
using Service.BaseService;
using Service.Interfaces;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Service.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // GET /discounts - For GetAll()
        public async Task<List<ReadDiscountDTO>?> GetAllDiscountsAsync()
        {
            var response = await _httpClient.GetAsync("/discounts");

            if (!response.IsSuccessStatusCode)
            {
                // Return null if the request fails
                return null;
            }

            // Deserialize directly into List<ReadDiscountDTO>
            return await response.Content.ReadFromJsonAsync<List<ReadDiscountDTO>>();
        }

        // GET /discounts/{id} - For GetById()
        public async Task<ReadDiscountDTO?> GetDiscountByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/discounts/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ReadDiscountDTO>();
        }

        // GET /discounts/code/{code} - For GetByCode()
        public async Task<ReadDiscountDTO?> GetDiscountByCodeAsync(string code)
        {

            var response = await _httpClient.GetAsync($"/discounts/code/{code}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ReadDiscountDTO>();
        }

        // GET /discounts/stadium/{stadiumId} - For GetByStadiumId()
        public async Task<List<ReadDiscountDTO>?> GetDiscountsByStadiumIdAsync(int stadiumId)
        {
            var response = await _httpClient.GetAsync($"/discounts/stadium/{stadiumId}");

            if (!response.IsSuccessStatusCode)
            {
                // Return null if the request fails
                return null;
            }

            // Deserialize directly into List<ReadDiscountDTO>
            return await response.Content.ReadFromJsonAsync<List<ReadDiscountDTO>>();
        }

        // POST /discounts - For Create()
        public async Task<ReadDiscountDTO?> CreateDiscountAsync(string accessToken, CreateDiscountDTO dto)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.PostAsJsonAsync("/discounts", dto);

            if (!response.IsSuccessStatusCode)
            {
                // Return null on failure instead of throwing a generic exception
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ReadDiscountDTO>();
        }

        // PUT /discounts - For Update()
        public async Task<bool> UpdateDiscountAsync(string accessToken, UpdateDiscountDTO dto)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.PutAsJsonAsync("/discounts", dto);

            // Return true if the update was successful (204 NoContent)
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ReadDiscountDTO>?> GetDiscountsByUserAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);
            var response = await _httpClient.GetAsync($"/discounts");
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<List<ReadDiscountDTO>>();
        }
    }
}