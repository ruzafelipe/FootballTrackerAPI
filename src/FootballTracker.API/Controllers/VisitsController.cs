using FootballTracker.API.DTOs.Visits;
using FootballTracker.API.Mappers;
using FootballTracker.Application.UseCases.Visits.GetVisitById;
using FootballTracker.Application.UseCases.Visits.ListVisitsByMatch;
using FootballTracker.Application.UseCases.Visits.ListVisitsByUser;
using FootballTracker.Application.UseCases.Visits.RegisterVisit;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;


[ApiController]
[Route("api/visits")]
public class VisitsController : ControllerBase
{
    private readonly RegisterVisitHandler _registerVisitHandler;
    private readonly ListVisitsByUserHandler _listVisitsByUserHandler;
    private readonly ListVisitsByMatchHandler _listVisitsByMatchHandler;
    private readonly GetVisitByIdHandler _getVisitByIdHandler;
    public VisitsController(
            RegisterVisitHandler registerVisitHandler,
            ListVisitsByUserHandler listVisitsByUserHandler,
            ListVisitsByMatchHandler listVisitsByMatchHandler,
            GetVisitByIdHandler getVisitByIdHandler
        )
    {
        _registerVisitHandler = registerVisitHandler;
        _listVisitsByUserHandler = listVisitsByUserHandler;
        _listVisitsByMatchHandler = listVisitsByMatchHandler;
        _getVisitByIdHandler = getVisitByIdHandler;
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

    // GET: api/visits/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetVisitByIdQuery(id);

        var result = await _getVisitByIdHandler.HandleAsync(query);

        if (!result.IsSuccess)
            return NotFound(result.Error);

        var response = VisitMapper.ToDetailsResponse(result.Value!);

        return Ok(response);
    }

    // GET: api/visits/user/{userId}
    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetByUser(Guid userId)
    {
        var query = new ListVisitsByUserQuery(userId);

        var result = await _listVisitsByUserHandler.HandleAsync(query);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        var response = result.Value!
            .Select(VisitMapper.ToListResponse)
            .ToList();

        return Ok(response);
    }

    // GET: api/visits/match/{matchId}
    [HttpGet("match/{matchId:guid}")]
    public async Task<IActionResult> GetByMatch(Guid matchId)
    {
        var query = new ListVisitsByMatchQuery(matchId);

        var result = await _listVisitsByMatchHandler.HandleAsync(query);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        var response = result.Value!
            .Select(VisitMapper.ToListResponse)
            .ToList();

        return Ok(response);
    }
}
