using FootballTracker.API.DTOs.Users;
using FootballTracker.Application.UseCases.Users.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UsersController : ControllerBase
{
    private readonly RegisterUserHandler _handler;

    public UsersController(RegisterUserHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var command = new RegisterUserCommand(
            request.Name,
            request.Email
        );

        var userId = await _handler.HandleAsync(command);

        return CreatedAtAction(
            nameof(Register),
            new { id = userId },
            new { userId }
        );
    }
}
