using Microsoft.AspNetCore.Mvc;
using Patronage.Application.FizzBuzz.Queries;
using System.Threading.Tasks;

namespace Patronage.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get([FromQuery]GetFizzBuzzQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}