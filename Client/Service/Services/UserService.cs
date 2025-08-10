using DTOs.UserDTO;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/users/login", loginRequestDTO);
            response.EnsureSuccessStatusCode();  // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }

        public async Task<bool> RegisterAsync(RegisterRequestDTO dto)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(dto.FullName), nameof(dto.FullName));
            form.Add(new StringContent(dto.Email), nameof(dto.Email));
            form.Add(new StringContent(dto.Password), nameof(dto.Password));
            form.Add(new StringContent(dto.Role ?? "None"), nameof(dto.Role));

            if (!string.IsNullOrEmpty(dto.Address))
                form.Add(new StringContent(dto.Address), nameof(dto.Address));

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
                form.Add(new StringContent(dto.PhoneNumber), nameof(dto.PhoneNumber));

            if (dto.Avatar != null)
            {
                var avatarContent = new StreamContent(dto.Avatar.OpenReadStream());
                avatarContent.Headers.ContentType =
                    new MediaTypeHeaderValue(dto.Avatar.ContentType);
                form.Add(avatarContent, nameof(dto.Avatar), dto.Avatar.FileName);
            }

            if (dto.FaceImage != null)
            {
                var faceContent = new StreamContent(dto.FaceImage.OpenReadStream());
                faceContent.Headers.ContentType =
                    new MediaTypeHeaderValue(dto.FaceImage.ContentType);
                form.Add(faceContent, nameof(dto.FaceImage), dto.FaceImage.FileName);
            }

            var response = await _httpClient.PostAsync("/users/register", form);
            return response.IsSuccessStatusCode;
        }

        public async Task<LogoutResponseDTO> LogoutAsync(LogoutRequestDTO logoutRequestDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/users/logout", logoutRequestDTO);
            response.EnsureSuccessStatusCode();  // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadFromJsonAsync<LogoutResponseDTO>();
        }

        public async Task<LoginResponseDTO> RefreshTokenAsync(RefreshTokenRequestDTO refreshTokenRequestDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/users/refreshToken", refreshTokenRequestDTO);
            response.EnsureSuccessStatusCode();  // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }

        public async Task<ReadUserDTO?> GetProfileAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);

            var response = await _httpClient.GetAsync("/users/info");
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<ReadUserDTO>();
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            var response = await _httpClient.PostAsJsonAsync($"/users/checkEmail", email);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<bool>();
                return result;
            }
            else
            {
                throw new HttpRequestException($"Error checking email existence: {response.ReasonPhrase}");
            }
        }
    }
}
