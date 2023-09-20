using ErrorOr;
using MediatR;
using PumpingControl.Application.Common.Enums;
using PumpingControl.Application.PlayerBehaviors.Contracts;

namespace PumpingControl.Application.PlayerBehaviors.Commands;

public record UpdatePlayerPointsCommand(Guid PlayerId, decimal Points, ActionsForPoints Action) : IRequest<ErrorOr<decimal>>;