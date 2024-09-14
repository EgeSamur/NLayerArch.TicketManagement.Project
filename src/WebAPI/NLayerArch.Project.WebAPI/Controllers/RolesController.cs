using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerArch.Project.Bussines.Base.RequestBase;
using NLayerArch.Project.Bussines.Features.Roles.Dtos;
using NLayerArch.Project.Bussines.Features.Roles.Services;

namespace NLayerArch.Project.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;

        public RolesController(IRoleService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest request)
        {
            var result = await _service.GetAllAsync(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoleDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }
        [HttpPost("set-permissions")]
        public async Task<IActionResult> SetPermissions([FromBody] SetRoleOperationClaimsDto dto)
        {
            await _service.SetPermissionsAsync(dto);
            return Ok();
        }
    }
}
