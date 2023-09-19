using FluentValidation;
using PumpingControl.Application.PlayerBehaviors.Commands;

namespace PumpingControl.Application.PlayerBehaviors.Validators;

public class RemovePointsForPlayerCommandValidator : AbstractValidator<RemovePointsFromPlayerCommand>
{
    public RemovePointsForPlayerCommandValidator()
    {
        RuleFor(x => x.PlayerId)
            .NotEmpty();

        RuleFor(x => x.Points)
            .GreaterThan(0);
    }
}