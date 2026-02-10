using FootballTracker.API.DTOs.Visits;
using FootballTracker.Application.UseCases.Visits.RegisterVisit;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;


[ApiController]
[Route("api/visits")]
public class VisitsController : ControllerBase
{
    private readonly RegisterVisitHandler _registerVisitHandler;
    public VisitsController(RegisterVisitHandler registerVisitHandler)
    {
        _registerVisitHandler = registerVisitHandler;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterVisit([FromBody] RegisterVisitRequest request)
    {
        var command = new RegisterVisitCommand(
            request.UserId,
            request.VisitDate,
            request.MatchId,
            request.MatchData
        );
        var result = await _registerVisitHandler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Created(string.Empty, null);
    }
}
