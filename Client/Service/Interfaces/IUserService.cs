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

        Task<bool> CustomerRegisterAsync(CustomerRegisterRequestDTO registerRequestDTO);

        Task<bool> StadiumManagerRegisterAsync(StadiumManagerRegisterRequestDTO registerRequestDTO);

        Task<PrivateUserProfileDTO?> GetMyProfileAsync(string accessToken);

        Task<PublicUserProfileDTO?> GetOtherUserByIdAsync(string userId);

        Task<LogoutResponseDTO> LogoutAsync(LogoutRequestDTO logoutRequestDTO);

        Task<LoginResponseDTO> RefreshTokenAsync(RefreshTokenRequestDTO refreshTokenRequestDTO);

        Task<bool> IsEmailExistsAsync(string email);

        Task<PrivateUserProfileDTO> UpdateUserProfileAsync(UpdateUserProfileDTO updateUserProfileDTO, string accessToken);

        Task<PrivateUserProfileDTO> UpdateAvatarAsync(UpdateAvatarDTO updateAvatarDTO, string accessToken);

        Task<PrivateUserProfileDTO> UpdateFaceImageAsync(UpdateFaceImageDTO updateFaceImageDTO, string accessToken);

        Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
    }
}
