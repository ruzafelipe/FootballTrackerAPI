using FootballTracker.API.DTOs.Matchs;
using FootballTracker.Application.UseCases.Matchs.RegisterMatch;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;

[ApiController]
[Route("api/matchs")]
public class MatchsController : ControllerBase
{
    private readonly RegisterMatchHandler _handler;

    public MatchsController(RegisterMatchHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterMatchRequest request)
    {
        var command = new RegisterMatchCommand(
            request.MatchDate,
            request.StadiumId,
            request.HomeClubId,
            request.AwayClubId);
        var result = await _handler.HandleAsync(command);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Created(string.Empty, null);
    }
}
