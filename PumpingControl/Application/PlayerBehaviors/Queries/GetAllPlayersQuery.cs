using ErrorOr;
using MediatR;
using PumpingControl.Application.Common.Enums;
using PumpingControl.Application.PlayerBehaviors.Results;

namespace PumpingControl.Application.PlayerBehaviors.Queries;

public record GetAllPlayersQuery(OrderByParameter? Parameter) : IRequest<ErrorOr<List<PlayerResult>>>;