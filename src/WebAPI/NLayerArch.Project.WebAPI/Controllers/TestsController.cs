using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerArch.Project.Bussines.Features.Auth.Dtos;

namespace NLayerArch.Project.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestsController : ControllerBase
    {

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}
