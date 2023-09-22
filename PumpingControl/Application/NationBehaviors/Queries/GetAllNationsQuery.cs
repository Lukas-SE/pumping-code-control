using ErrorOr;
using MediatR;
using PumpingControl.Application.Common.Enums;
using PumpingControl.Application.NationBehaviors.Results;

namespace PumpingControl.Application.NationBehaviors.Queries;

public record GetAllNationsQuery(OrderByParameter? Parameter) : IRequest<ErrorOr<List<NationResult>>>;