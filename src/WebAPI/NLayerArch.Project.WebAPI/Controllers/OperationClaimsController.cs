using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerArch.Project.Bussines.Base.RequestBase;
using NLayerArch.Project.Bussines.Features.OperationClaims.Dtos;
using NLayerArch.Project.Bussines.Features.OperationClaims.Services;
using NLayerArch.Project.Bussines.Features.Users.Dtos;

namespace NLayerArch.Project.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly IOperationClaimService _service;

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _service = operationClaimService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOperationClaimDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}
