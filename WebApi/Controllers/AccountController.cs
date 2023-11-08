using Application.Features.Account.AccountQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.Account.AccountCommands.AccountCommands;

[ApiController]
[ApiVersion("2.0")]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        RegisterCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        LoginCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsers query)
    {
        GetAllUsersResponse response = await _mediator.Send(query);
        return Ok(response);
    }


    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById([FromQuery] GetUserById query)
    {
        GetUserByIdResponse response = await _mediator.Send(query);
        return Ok(response);
    }

}
