using ErrorOr;
using MediatR;
using PumpingControl.Application.PlayerBehaviors.Queries;
using PumpingControl.Application.PlayerBehaviors.Results;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.PlayerBehaviors.Handlers;

public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, ErrorOr<PlayerResult>>
{
    private readonly IPlayerRepository _playerRepository;

    public GetPlayerQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<PlayerResult>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        var player = await _playerRepository.GetByIdAsync(request.Id);

        if (player is null) return Error.NotFound();

        return new PlayerResult(
            player.Id,
            player.Name,
            player.Email,
            player.BusinessUnit,
            player.Balance,
            player.NationId
        );
    }
}