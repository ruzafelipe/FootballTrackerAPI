using FootballTracker.API.DTOs.Stadiums;
using FootballTracker.API.Mappers;

using FootballTracker.Application.UseCases.Stadiums.ActivateStadium;
using FootballTracker.Application.UseCases.Stadiums.DeactivateStadium;
using FootballTracker.Application.UseCases.Stadiums.GetStadiumById;
using FootballTracker.Application.UseCases.Stadiums.ListStadiums;
using FootballTracker.Application.UseCases.Stadiums.RegisterStadium;
using FootballTracker.Application.UseCases.Stadiums.UpdateStadium;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;


[ApiController]
[Route("api/stadiums")]
public class StadiumsController : ControllerBase
{
    private readonly RegisterStadiumHandler _registerStadiumHandler;
    private readonly UpdateStadiumHandler _updateStadiumHandler;
    private readonly ActivateStadiumHandler _activateStadiumHandler;
    private readonly DeactivateStadiumHandler _deactivateStadiumHandler;
    private readonly ListStadiumHandler _listStadiumHandler;
    private readonly GetStadiumByIdHandler _getStadiumByIdHandler;

    public StadiumsController(RegisterStadiumHandler registerStadiumHandler,
        UpdateStadiumHandler updateStadiumHandler,
        ActivateStadiumHandler activateStadiumHandler,
        DeactivateStadiumHandler deactivateStadiumHandler,
        ListStadiumHandler listStadiumHandler,
        GetStadiumByIdHandler getStadiumByIdHandler)
    {
        _registerStadiumHandler = registerStadiumHandler;
        _updateStadiumHandler = updateStadiumHandler;
        _activateStadiumHandler = activateStadiumHandler;
        _deactivateStadiumHandler = deactivateStadiumHandler;
        _listStadiumHandler = listStadiumHandler;
        _getStadiumByIdHandler = getStadiumByIdHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterStadiumRequest request)
    {
        var command = new RegisterStadiumCommand(request.Name,
            request.City,
            request.State,
            request.Country,
            request.Capacity,
            request.OpenedDate,
            request.PhotoUrl);

        var result = await _registerStadiumHandler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Created(string.Empty, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStadiumRequest request)
    {
        var command = new UpdateStadiumCommand(id,
            request.Name,
            request.City,
            request.State,
            request.Country,
            request.Capacity,
            request.OpenedDate,
            request.PhotoUrl);

        var result = await _updateStadiumHandler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return NoContent();
    }

    [HttpPatch("{id:guid}/activate")]
    public async Task<IActionResult> Activate(Guid id)
    {
        var command = new ActivateStadiumCommand(id);
        var result = await _activateStadiumHandler.HandleAsync(command);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return NoContent();
    }


    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        var command = new DeactivateStadiumCommand(id);
        var result = await _deactivateStadiumHandler.HandleAsync(command);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] bool onlyActive = true)
    {
        var stadiums = await _listStadiumHandler.HandleAsync(onlyActive);
        var response = stadiums.Select(StadiumMapper.ToResponse);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetStadiumByIdQuery(id);

        var result = await _getStadiumByIdHandler.HandleAsync(query);

        if (!result.IsSuccess)
            return NotFound(result.Error);

        //var response = StadiumMapper.ToDetailsResponse(result.Value!);
        return Ok(StadiumMapper.ToDetailsResponse(result.Value!));
    }
}
