using ErrorOr;
using MediatR;
using PumpingControl.Domain;

namespace PumpingControl.Application.PlayerBehaviors.Queries;

public record GetPlayerQuery(Guid Id) : IRequest<ErrorOr<Player>>;