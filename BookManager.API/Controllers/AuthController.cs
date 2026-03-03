using BookManager.Application.Features.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    { 
      private readonly IMediator _mediators;
        public AuthController(IMediator mediator) { _mediators = mediator; }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var token = await _mediators.Send(command);
            return Ok(new { token });

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var token = await _mediators.Send(command);
            return Ok(new { token });

        }
    }
}
