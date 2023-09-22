using ErrorOr;
using MediatR;
using PumpingControl.Application.Common.Enums;
using PumpingControl.Application.PlayerBehaviors.Results;

namespace PumpingControl.Application.PlayerBehaviors.Commands;

public record UpdatePlayerPointsCommand(Guid PlayerId, decimal Points, PointsAction Action) : IRequest<ErrorOr<PlayerResult>>;