using ErrorOr;
using MediatR;
using PumpingControl.Application.PlayerBehaviors.Queries;
using PumpingControl.Data.Repositories;
using PumpingControl.Domain;

namespace PumpingControl.Application.PlayerBehaviors.Handlers;

public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, ErrorOr<Player>>
{
    private readonly IPlayerRepository _playerRepository;

    public GetPlayerQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<Player>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        var player = await _playerRepository.GetByIdAsync(request.Id);

        if (player is null) return Error.NotFound();

        return player;
    }
}