using FootballTracker.API.DTOs.Competitions;
using FootballTracker.API.Mappers;
using FootballTracker.Application.UseCases.Competitions.ActivateCompetition;
using FootballTracker.Application.UseCases.Competitions.DeactivateCompetition;
using FootballTracker.Application.UseCases.Competitions.GetCompetitionById;
using FootballTracker.Application.UseCases.Competitions.ListCompetitions;
using FootballTracker.Application.UseCases.Competitions.RegisterCompetition;
using FootballTracker.Application.UseCases.Competitions.UpdateCompetition;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;

[ApiController]
[Route("api/competitions")]
public class CompetitionController : ControllerBase
{
    private readonly RegisterCompetitionHandler _registerCompetitionHandler;
    private readonly UpdateCompetitionHandler _updateCompetitionHandler;
    private readonly GetCompetitionByIdHandler _getCompetitionByIdHandler;
    private readonly ListCompetitionsHandler _listCompetitionsHandler;
    private readonly ActivateCompetitionHandler _activateCompetitionHandler;
    private readonly DeactivateCompetitionHandler _deactivateCompetitionHandler;

    public CompetitionController(
        RegisterCompetitionHandler registerCompetitionHandler,
        UpdateCompetitionHandler updateCompetitionHandler,
        GetCompetitionByIdHandler getCompetitionByIdHandler,
        ListCompetitionsHandler listCompetitionsHandler,
        ActivateCompetitionHandler activateCompetitionHandler,
        DeactivateCompetitionHandler deactivateCompetitionHandler)
    {
        _registerCompetitionHandler = registerCompetitionHandler;
        _updateCompetitionHandler = updateCompetitionHandler;
        _getCompetitionByIdHandler = getCompetitionByIdHandler;
        _listCompetitionsHandler = listCompetitionsHandler;
        _activateCompetitionHandler = activateCompetitionHandler;
        _deactivateCompetitionHandler = deactivateCompetitionHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterCompetitionRequest request)
    {
        var command = new RegisterCompetitionCommand(
            request.Name,
            request.Season,
            request.Type,
            request.Country,
            request.StartDate,
            request.EndDate);

        var result = await _registerCompetitionHandler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Created(string.Empty, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateCompetitionRequest request)
    {
        var currentResult = await _getCompetitionByIdHandler.HandleAsync(
        new GetCompetitionByIdQuery(id));

        if (!currentResult.IsSuccess)
            return NotFound(currentResult.Error);

        var current = currentResult.Value!;

        var command = new UpdateCompetitionCommand(
            id,
            request.Name ?? current.Name,
            request.Season ?? current.Season,
            request.Country ?? current.Country,
            request.StartDate ?? current.StartDate,
            request.EndDate ?? current.EndDate
            );

        var result = await _updateCompetitionHandler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return NoContent();
    }

    [HttpPatch("{id:guid}/activate")]
    public async Task<IActionResult> Activate(Guid id)
    {
        var command = new ActivateCompetitionCommand(id);
        var result = await _activateCompetitionHandler.HandleAsync(command);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return NoContent();
    }

    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        var command = new DeactivateCompetitionCommand(id);
        var result = await _deactivateCompetitionHandler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] bool onlyActive = true)
    {
        var query = new ListCompetitionsQuery(onlyActive);
        var competitions = await _listCompetitionsHandler.HandleAsync(query);
        var response = competitions.Select(CompetitionMapper.ToResponse);

        return Ok(response);

    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetCompetitionByIdQuery(id);

        var result = await _getCompetitionByIdHandler.HandleAsync(query);

        if (!result.IsSuccess)
            return NotFound(result.Error);        

        return Ok(CompetitionMapper.ToResponse(result.Value!));
    }
}
