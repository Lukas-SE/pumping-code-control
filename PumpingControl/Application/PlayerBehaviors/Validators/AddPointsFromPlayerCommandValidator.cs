using FluentValidation;
using PumpingControl.Application.PlayerBehaviors.Commands;

namespace PumpingControl.Application.PlayerBehaviors.Validators;

public class AddPointsFromPlayerCommandValidator : AbstractValidator<AddPointsForPlayerCommand>
{
    public AddPointsFromPlayerCommandValidator()
    {
        RuleFor(x => x.PlayerId)
            .NotEmpty();

        RuleFor(x => x.Points)
            .GreaterThan(0);
    }
}