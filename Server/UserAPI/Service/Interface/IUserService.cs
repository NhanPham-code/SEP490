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

        Task<PrivateUserProfileDTO> CustomerRegisterAsync(CustomerRegisterRequestDTO registerRequestDTO);

        Task<PrivateUserProfileDTO> StadiumManagerRegisterAsync(StadiumManagerRegisterRequestDTO registerRequestDTO);

        Task<PrivateUserProfileDTO> GetUserProfileAsync(int id);

        Task<PublicUserProfileDTO> GetOtherUserProfileAsync(int id);

        Task<bool> DeleteUserAsync(int id);

        Task<bool> IsEmailExistsAsync(string email);

        Task<PrivateUserProfileDTO> UpdateUserProfileAsync(UpdateUserProfileDTO updateUserProfileDTO);

        Task<PrivateUserProfileDTO> UpdateAvatarAsync(UpdateAvatarDTO updateAvatarDTO);
    }
}
