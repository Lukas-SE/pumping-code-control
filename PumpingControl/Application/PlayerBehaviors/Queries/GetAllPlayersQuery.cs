using ErrorOr;
using MediatR;
using PumpingControl.Application.PlayerBehaviors.Results;

namespace PumpingControl.Application.PlayerBehaviors.Queries;

public record GetAllPlayersQuery : IRequest<ErrorOr<GetAllPlayersResult>>;