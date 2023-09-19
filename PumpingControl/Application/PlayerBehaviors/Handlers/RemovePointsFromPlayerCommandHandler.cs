using ErrorOr;
using MediatR;
using PumpingControl.Application.PlayerBehaviors.Commands;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.PlayerBehaviors.Handlers;

public class RemovePointsFromPlayerCommandHandler : IRequestHandler<RemovePointsFromPlayerCommand, ErrorOr<Success>>
{
    private readonly IPlayerRepository _playerRepository;

    public RemovePointsFromPlayerCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<Success>> Handle(RemovePointsFromPlayerCommand request,
        CancellationToken cancellationToken)
    {
        var player = await _playerRepository.GetByIdAsync(request.PlayerId);

        if (player is null) return Error.NotFound();

        player.Balance -= request.Points;

        await _playerRepository.UpdateAsync(player);

        return Result.Success;
    }
}