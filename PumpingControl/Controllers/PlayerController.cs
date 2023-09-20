using MediatR;
using Microsoft.AspNetCore.Mvc;
using PumpingControl.Application.Common.Enums;
using PumpingControl.Application.PlayerBehaviors.Commands;
using PumpingControl.Application.PlayerBehaviors.Contracts;
using PumpingControl.Application.PlayerBehaviors.Queries;

namespace PumpingControl.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ApiController
{
    private readonly ISender _mediator;

    public PlayerController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var query = new GetAllPlayersQuery();
        var queryResult = await _mediator.Send(query);

        return queryResult.IsError ? Problem(queryResult.Errors) : Ok(queryResult.Value.Players);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPlayer(Guid id)
    {
        var query = new GetPlayerQuery(id);
        var queryResult = await _mediator.Send(query);

        return queryResult.IsError ? Problem(queryResult.Errors) : Ok(queryResult.Value);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePlayerPoints(Guid id, decimal amount, [FromQuery] ActionsForPoints action)
    {
        var command = new UpdatePlayerPointsCommand(id, amount, action);
        var commandResult = await _mediator.Send(command);

        return commandResult.IsError ? BadRequest(commandResult.Errors) : Ok(commandResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewPlayer(PlayerBody playerBody)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new CreateNewPlayerCommand(
            playerBody.Name, 
            playerBody.Email, 
            playerBody.BusinessUnit, 
            0, 
            playerBody.NationId);
        
        var commandResult = await _mediator.Send(command);

        return commandResult.IsError
            ? Problem(commandResult.Errors)
            : CreatedAtAction(nameof(GetPlayer), new { id = commandResult.Value.Id}, commandResult.Value);
    }
}