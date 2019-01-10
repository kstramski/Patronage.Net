using Application.Accounts.Commands.CreateAccount;
using Application.Accounts.Commands.LoginAccount;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginAccountCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateAccountCommand command)
        {
            //return Ok(await _accountService.Register(command.Email, command.Password));
            return Ok(await Mediator.Send(command));
        }
    }
}