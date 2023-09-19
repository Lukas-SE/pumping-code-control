using ErrorOr;
using MediatR;
using PumpingControl.Domain;

namespace PumpingControl.Application.NationBehaviors.Queries;

public record GetNationQuery(Guid Id) : IRequest<ErrorOr<Nation>>;