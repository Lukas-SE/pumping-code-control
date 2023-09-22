using ErrorOr;
using MediatR;
using PumpingControl.Application.PlayerBehaviors.Results;

namespace PumpingControl.Application.PlayerBehaviors.Commands;

public record CreateNewPlayerCommand
    (string Name, string Email, string BusinessUnit, decimal InitialBalance, Guid NationId) : IRequest<ErrorOr<PlayerResult>>;