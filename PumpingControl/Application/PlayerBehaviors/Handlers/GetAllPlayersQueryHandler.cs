using ErrorOr;
using MediatR;
using PumpingControl.Application.PlayerBehaviors.Queries;
using PumpingControl.Application.PlayerBehaviors.Results;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.PlayerBehaviors.Handlers;

public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, ErrorOr<GetAllPlayersResult>>
{
    private readonly IPlayerRepository _playerRepository;

    public GetAllPlayersQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<GetAllPlayersResult>> Handle(GetAllPlayersQuery request,
        CancellationToken cancellationToken)
    {
        var players = await _playerRepository.GetAllAsync();

        if (players is null) return Error.Unexpected();

        return new GetAllPlayersResult(players);
    }
}