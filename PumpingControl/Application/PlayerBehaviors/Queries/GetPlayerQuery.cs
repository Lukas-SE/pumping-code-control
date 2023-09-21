using ErrorOr;
using MediatR;
using PumpingControl.Application.PlayerBehaviors.Results;

namespace PumpingControl.Application.PlayerBehaviors.Queries;

public record GetPlayerQuery(Guid Id) : IRequest<ErrorOr<PlayerResult>>;