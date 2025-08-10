using System.Security.Claims;
using UserAPI.Model;

namespace UserAPI.Service.Interface
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        bool IsValidJwtFormat(string token);
    }
}
