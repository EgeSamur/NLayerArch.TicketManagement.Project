using Microsoft.IdentityModel.Tokens;

namespace NLayerArch.Project.Security.Encryption
{
    public static class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) =>
            new(securityKey, SecurityAlgorithms.HmacSha256Signature);
    }
}
