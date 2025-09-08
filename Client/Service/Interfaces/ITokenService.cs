using DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITokenService
    {
        string? GetAccessTokenFromHeader();
        string? GetAccessTokenFromCookie();
        string? GetRefreshTokenFromCookie();
        void SaveTokensToCookies(LoginResponseDTO response, bool rememberMe);
        void ClearTokens();
    }
}
