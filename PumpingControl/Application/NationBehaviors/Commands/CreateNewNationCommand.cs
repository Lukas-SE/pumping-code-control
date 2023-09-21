using ErrorOr;
using MediatR;
using PumpingControl.Application.NationBehaviors.Results;

namespace PumpingControl.Application.NationBehaviors.Commands;

public record CreateNewNationCommand(string Name) : IRequest<ErrorOr<NationResult>>;