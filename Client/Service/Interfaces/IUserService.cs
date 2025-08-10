using DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<bool> RegisterAsync(RegisterRequestDTO registerRequestDTO);
        Task<ReadUserDTO?> GetProfileAsync(string accessToken);
        Task<LogoutResponseDTO> LogoutAsync(LogoutRequestDTO logoutRequestDTO);
        Task<LoginResponseDTO> RefreshTokenAsync(RefreshTokenRequestDTO refreshTokenRequestDTO);
        Task<bool> IsEmailExistsAsync(string email);
    }
}
