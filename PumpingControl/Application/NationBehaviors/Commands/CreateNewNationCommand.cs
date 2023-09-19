using ErrorOr;
using MediatR;
using PumpingControl.Domain;

namespace PumpingControl.Application.NationBehaviors.Commands;

public record CreateNewNationCommand(string Name) : IRequest<ErrorOr<Nation>>;