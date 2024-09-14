using NLayerArch.Project.Bussines.Features.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Bussines.Features.Auth.Services
{
    public interface IAuthService
    {
        Task<LoggedDto> LoginAsync(LoginDto dto);
        Task<LoggedDto> RegisterAsync(RegisterDto dto);
        Task<LoggedDto> RefreshTokenAsync(RefreshTokenDto refreshToken);
        Task RevokeAsync(RevokeDto dto);
        Task RevokeAllAsync();
    }
}
