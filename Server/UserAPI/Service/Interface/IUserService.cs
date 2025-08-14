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

        Task<bool> DeleteUserAsync(int id);

        Task<bool> IsEmailExistsAsync(string email);

        Task<ReadUserDTO> UpdateUserProfileAsync(UpdateUserProfileDTO updateUserProfileDTO);

        Task<ReadUserDTO> UpdateAvatarAsync(UpdateAvatarDTO updateAvatarDTO);

        Task<ReadUserDTO> UpdateFaceImageAsync(UpdateFaceImageDTO updateFaceImageDTO);
    }
}
