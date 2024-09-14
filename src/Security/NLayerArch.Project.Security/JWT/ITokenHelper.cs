using NLayerArch.Project.Domain.Entites.Auth;
using System.Security.Claims;

namespace NLayerArch.Project.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }


}
