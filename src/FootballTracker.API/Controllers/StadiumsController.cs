using FootballTracker.API.DTOs.Stadiums;
using FootballTracker.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;


[ApiController]
[Route("api/stadiums")]
public class StadiumsController : ControllerBase
{
    private readonly RegisterStadiumHandler _handler;

    public StadiumsController(RegisterStadiumHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterStadiumRequest request)
    {
        var command = new RegisterStadiumCommand(request.Name, request.City);
        var result = await _handler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Created(string.Empty, null);
    }
}
