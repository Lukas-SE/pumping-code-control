using System.ComponentModel;
using ErrorOr;
using MediatR;
using PumpingControl.Application.Common.Enums;
using PumpingControl.Application.PlayerBehaviors.Commands;
using PumpingControl.Application.PlayerBehaviors.Results;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.PlayerBehaviors.Handlers;

public class UpdatePlayerPointsCommandHandler : IRequestHandler<UpdatePlayerPointsCommand, ErrorOr<PlayerResult>>
{
    private readonly IPlayerRepository _playerRepository;

    public UpdatePlayerPointsCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<PlayerResult>> Handle(UpdatePlayerPointsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);

            if (player is null) return Error.NotFound();

            player.Balance = HandlePoints(player.Balance, request);

            await _playerRepository.UpdateAsync(player);

            return new PlayerResult(
                player.Id,
                player.Name,
                player.Email,
                player.BusinessUnit,
                player.Balance,
                player.NationId
            );
        }
        catch (InvalidEnumArgumentException)
        {
            return Error.Unexpected();
        }
    }

    private decimal HandlePoints(decimal balance, UpdatePlayerPointsCommand request)
    {
        return request.Action switch
        {
            PointsAction.AddPoints => balance + request.Points > decimal.MaxValue
                ? decimal.MaxValue : balance += request.Points,
            PointsAction.SubtractPoints => balance - request.Points < 0 
                ? 0 : balance -= request.Points,
            PointsAction.SetPoints => request.Points,
            _ => throw new InvalidEnumArgumentException()
        };
    }
}