using Microsoft.AspNetCore.Identity.Data;
using UserAPI.DTOs;
using UserAPI.Model;

namespace UserAPI.Service.Interface
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsersForOData();

        Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);

        Task<LoginResponseDTO> CheckLoginAsync(LoginRequestDTO loginRequestDTO);

        Task<LoginResponseDTO> RefreshTokenAsync(RefreshTokenRequestDTO refreshTokenRequestDTO);

        Task<LogoutResponseDTO> LogoutAsync(LogoutRequestDTO logoutRequestDTO);

        Task<ReadUserDTO> RegisterAsync(RegisterRequestDTO registerRequestDTO);

        Task<ReadUserDTO> GetUserByIdAsync(int id);

        Task<ReadUserDTO> CreateUserAsync(RegisterRequestDTO createUserDTO);

        Task<ReadUserDTO> UpdateUserAsync(UpdateUserProfileDTO updateUserProfileDTO);

        Task<bool> DeleteUserAsync(int id);

        Task<bool> IsEmailExistsAsync(string email);
    }
}
