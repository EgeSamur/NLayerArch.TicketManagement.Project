using Microsoft.AspNetCore.Mvc;
using NLayerArch.Project.Bussines.Features.Auth.Dtos;
using NLayerArch.Project.Bussines.Features.Auth.Services;
using NLayerArch.Project.Bussines.Features.Roles.Dtos;

namespace NLayerArch.Project.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService authService)
        {
            _service = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _service.RegisterAsync(dto);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _service.LoginAsync(dto);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Revoke([FromBody] RevokeDto dto)
        {
            await _service.RevokeAsync(dto);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            await _service.RevokeAllAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
        {
            var result = await _service.RefreshTokenAsync(dto);
            return Ok(result);
        }



    }
}
