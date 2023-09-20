using ErrorOr;
using MediatR;
using PumpingControl.Application.Common.Enums;

namespace PumpingControl.Application.PlayerBehaviors.Commands;

public record UpdatePlayerPointsCommand(Guid PlayerId, decimal Points, ActionsForPoints Action) : IRequest<ErrorOr<decimal>>;