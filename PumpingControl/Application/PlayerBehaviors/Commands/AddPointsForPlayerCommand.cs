using ErrorOr;
using MediatR;

namespace PumpingControl.Application.PlayerBehaviors.Commands;

public record AddPointsForPlayerCommand(Guid PlayerId, decimal Points) : IRequest<ErrorOr<Success>>;