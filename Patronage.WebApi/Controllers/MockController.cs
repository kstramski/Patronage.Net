using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Patronage.Application.Mock.Queries;

namespace Patronage.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new MockQuery()));
        }
    }
}