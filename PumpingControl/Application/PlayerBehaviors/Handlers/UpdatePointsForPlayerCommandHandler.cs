using System.ComponentModel;
using ErrorOr;
using MediatR;
using PumpingControl.Application.Common.Enums;
using PumpingControl.Application.PlayerBehaviors.Commands;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.PlayerBehaviors.Handlers;

public class UpdatePlayerPointsCommandHandler : IRequestHandler<UpdatePlayerPointsCommand, ErrorOr<decimal>>
{
    private readonly IPlayerRepository _playerRepository;

    public UpdatePlayerPointsCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<decimal>> Handle(UpdatePlayerPointsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);

            if (player is null) return Error.NotFound();

            player.Balance = HandlePoints(player.Balance, request);

            await _playerRepository.UpdateAsync(player);

            return player.Balance;
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
            ActionsForPoints.AddPoints => balance + request.Points > decimal.MaxValue
                                        ? decimal.MaxValue : balance += request.Points,
            ActionsForPoints.SubtractPoints => balance - request.Points < 0 
                                        ? 0 : balance -= request.Points,
            ActionsForPoints.SetPoints => request.Points,
            _ => throw new InvalidEnumArgumentException()
        };
    }
}