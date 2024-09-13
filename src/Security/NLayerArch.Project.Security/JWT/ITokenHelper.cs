using NLayerArch.Project.Domain.Entites.Auth;

namespace NLayerArch.Project.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
        string GenerateRefreshToken();
    }


}
