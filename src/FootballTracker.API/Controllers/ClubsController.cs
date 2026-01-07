using FootballTracker.API.DTOs.Clubs;
using FootballTracker.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;


[ApiController]
[Route("api/clubs")]
public class ClubsController : ControllerBase
{
    private readonly RegisterClubHandler _handler;
    public ClubsController(RegisterClubHandler handler)
    {
        _handler = handler;
    }
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterClubRequest request)
    {
        var command = new RegisterClubCommand(request.Name);
        var result = await _handler.HandleAsync(command);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Created(string.Empty, null);
    }
}
