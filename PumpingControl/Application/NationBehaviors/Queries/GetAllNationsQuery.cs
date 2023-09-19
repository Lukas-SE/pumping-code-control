using ErrorOr;
using MediatR;
using PumpingControl.Application.NationBehaviors.Results;

namespace PumpingControl.Application.NationBehaviors.Queries;

public record GetAllNationsQuery : IRequest<ErrorOr<GetAllNationsResult>>;