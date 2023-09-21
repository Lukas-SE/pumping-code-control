using System.ComponentModel;
using ErrorOr;
using MediatR;
using PumpingControl.Application.Common.Enums;
using PumpingControl.Application.PlayerBehaviors.Queries;
using PumpingControl.Application.PlayerBehaviors.Results;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.PlayerBehaviors.Handlers;

public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, ErrorOr<List<PlayerResult>>>
{
    private readonly IPlayerRepository _playerRepository;

    public GetAllPlayersQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<List<PlayerResult>>> Handle(GetAllPlayersQuery request,
        CancellationToken cancellationToken)
    {
        var players = await _playerRepository.GetAllAsync();

        if (players is null) return Error.Unexpected();

        var response = players.Select(x =>
                new PlayerResult(x.Id, x.Name, x.Email, x.BusinessUnit, x.Balance, x.NationId)).ToList();

        if (request.Parameter != null) response = SortPlayers(response, request.Parameter);

        return response;
    }

    public List<PlayerResult> SortPlayers(List<PlayerResult> players, OrderByParameter? param)
    {
        List<PlayerResult>? data;
        switch (param)
        {
            case OrderByParameter.Score: return data = players.OrderByDescending(x => x.Balance).ToList();
            case OrderByParameter.Name: return data = players.OrderBy(x => x.Name).ToList();
            default: throw new InvalidEnumArgumentException();
        }
    }
}