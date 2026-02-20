using FootballTracker.API.DTOs.Matchs;
using FootballTracker.API.Mappers;
using FootballTracker.Application.UseCases.Matchs.ApproveMatch;
using FootballTracker.Application.UseCases.Matchs.GetMatchById;
using FootballTracker.Application.UseCases.Matchs.ListMatches;
using FootballTracker.Application.UseCases.Matchs.RejectMatch;
using FootballTracker.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;

[ApiController]
[Route("api/matchs")]
public class MatchsController : ControllerBase
{

    private readonly ApproveMatchHandler _approveMatchHandler;
    private readonly RejectMatchHandler _rejectMatchHandler;
    private readonly ListMatchesHandler _listMatchesHandler;
    private readonly GetMatchByIdHandler _getMatchByIdHandler;

    public MatchsController(
        ApproveMatchHandler approveMatchHandler,
        RejectMatchHandler rejectMatchHandler,
        ListMatchesHandler listMatchesHandler,
        GetMatchByIdHandler getMatchByIdHandler
        )
    {
        _approveMatchHandler = approveMatchHandler;
        _rejectMatchHandler = rejectMatchHandler;
        _listMatchesHandler = listMatchesHandler;
        _getMatchByIdHandler = getMatchByIdHandler;
    }

    [HttpPost("{id}/approve")]
    public async Task<IActionResult> ApproveMatch(Guid id, [FromBody] ApproveMatchRequest request)
    {
        var command = new ApproveMatchCommand(id, request.ApprovedByUserId);
        var result = await _approveMatchHandler.HandleAsync(command);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Ok();
    }

    [HttpPost("{id}/reject")]
    public async Task<IActionResult> RejectMatch(Guid id, [FromBody] RejectMatchRequest request)
    {
        var command = new RejectMatchCommand(id, request.RejectedByUserId);
        var result = await _rejectMatchHandler.HandleAsync(command);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var query = new ListMatchesQuery(new[]
        {
            MatchStatus.Approved,
            MatchStatus.Pending
        });

        var result = await _listMatchesHandler.HandleAsync(query);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        var response = result.Value!
            .Select(MatchMapper.ToListResponse);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetMatchByIdQuery(id);
        var result = await _getMatchByIdHandler.HandleAsync(query);
        if (!result.IsSuccess)
            return NotFound(result.Error);
        
        return Ok(MatchMapper.ToDetailsResponse(result.Value!));
    }

    
}
