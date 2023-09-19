using ErrorOr;
using MediatR;
using PumpingControl.Domain;

namespace PumpingControl.Application.PlayerBehaviors.Commands;

public record CreateNewPlayerCommand
    (string Name, string Email, string BusinessUnit, decimal InitialBalance, Guid NationId) : IRequest<ErrorOr<Player>>;