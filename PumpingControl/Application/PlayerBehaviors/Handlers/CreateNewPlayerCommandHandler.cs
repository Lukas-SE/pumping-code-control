using ErrorOr;
using MediatR;
using PumpingControl.Application.PlayerBehaviors.Commands;
using PumpingControl.Application.PlayerBehaviors.Results;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.PlayerBehaviors.Handlers;

public class CreateNewPlayerCommandHandler : IRequestHandler<CreateNewPlayerCommand, ErrorOr<PlayerResult>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly INationRepository _nationRepository;

    public CreateNewPlayerCommandHandler(
        IPlayerRepository playerRepository, 
        INationRepository nationRepository)
    {
        _playerRepository = playerRepository;
        _nationRepository = nationRepository;
    }

    public async Task<ErrorOr<PlayerResult>> Handle(CreateNewPlayerCommand request, CancellationToken cancellationToken)
    {
        var existentPlayer = await _playerRepository.GetByEmailAsync(request.Email);

        if (existentPlayer is not null)
            return Error.Conflict();
        
        var existentNation = await _nationRepository.GetByIdAsync(request.NationId);

        if (existentNation is null)
            return Error.NotFound(description: $"Nation {request.NationId} not found");        
        
        var player = new Domain.Player
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            BusinessUnit = request.BusinessUnit,
            Balance = request.InitialBalance,
            Nation = existentNation
        };

        try
        {
            await _playerRepository.AddAsync(player);
        }
        catch (Exception e)
        {
            return Error.Failure(e.Message);
        }

        return new PlayerResult(
            player.Id, player.Name,
            player.Email,
            player.BusinessUnit,
            player.Balance,
            existentNation.Id
        );
    }
}