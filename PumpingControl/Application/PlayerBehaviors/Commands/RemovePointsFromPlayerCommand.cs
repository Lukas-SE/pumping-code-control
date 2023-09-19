using ErrorOr;
using MediatR;

namespace PumpingControl.Application.PlayerBehaviors.Commands;

public record RemovePointsFromPlayerCommand(Guid PlayerId, decimal Points) : IRequest<ErrorOr<Success>>;