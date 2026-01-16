using FootballTracker.API.DTOs.Clubs;
using FootballTracker.API.Mappers;
using FootballTracker.Application.UseCases.Clubs.ActivateClub;
using FootballTracker.Application.UseCases.Clubs.DeactivateClub;
using FootballTracker.Application.UseCases.Clubs.GetClubById;
using FootballTracker.Application.UseCases.Clubs.ListClubs;
using FootballTracker.Application.UseCases.Clubs.RegisterClub;
using FootballTracker.Application.UseCases.Clubs.UpdateClub;
using Microsoft.AspNetCore.Mvc;

namespace FootballTracker.API.Controllers;


[ApiController]
[Route("api/clubs")]
public class ClubsController : ControllerBase
{
    private readonly RegisterClubHandler _registerClubHandler;
    private readonly UpdateClubHandler _updateClubHandler;
    private readonly DeactivateClubHandler _deactivateClubHandler;
    private readonly ActivateClubHandler _activateClubHandler;
    private readonly ListClubHandler _listClubHandler;
    private readonly GetClubByIdHandler _getClubByIdHandler;

    public ClubsController(
        RegisterClubHandler registerClubHandler,
        UpdateClubHandler updateClubHandler,
        DeactivateClubHandler deactivateClubHandler,
        ActivateClubHandler activateClubHandler,
        ListClubHandler listClubHandler,
        GetClubByIdHandler getClubByIdHandler)
    {
        _registerClubHandler = registerClubHandler;
        _updateClubHandler = updateClubHandler;
        _deactivateClubHandler = deactivateClubHandler;
        _activateClubHandler = activateClubHandler;
        _listClubHandler = listClubHandler;
        _getClubByIdHandler = getClubByIdHandler;
    }


    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterClubRequest request)
    {
        var command = new RegisterClubCommand(
            request.Name,
            request.City,
            request.State,
            request.Country,
            request.FoundedAt,
            request.LogoUrl);

        var result = await _registerClubHandler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Created(string.Empty, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClubRequest request)
    {
        var command = new UpdateClubCommand(
            id,
            request.Name,
            request.City,
            request.State,
            request.Country,
            request.FoundedAt,
            request.LogoUrl);

        var result = await _updateClubHandler.HandleAsync(command); 

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return NoContent();
    }


    [HttpPatch("{id:guid}/activate")]
    public async Task<IActionResult> Activate(Guid id)
    {
        var command = new ActivateClubCommand(id);
        var result = await _activateClubHandler.HandleAsync(command);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return NoContent();
    }

    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        var command = new DeactivateClubCommand(id);
        var result = await _deactivateClubHandler.HandleAsync(command);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] bool onlyActive = true)
    {
        var clubs = await _listClubHandler.HandleAsync(onlyActive);
        var response = clubs.Select(ClubMapper.ToResponse);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetClubByIdQuery(id);

        var result = await _getClubByIdHandler.HandleAsync(query);

        if (!result.IsSuccess)
            return NotFound(result.Error);

        return Ok(ClubMapper.ToDetailsResponse(result.Value));
    }

}
