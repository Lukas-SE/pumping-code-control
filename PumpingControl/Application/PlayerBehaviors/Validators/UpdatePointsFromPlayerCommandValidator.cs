using FluentValidation;
using PumpingControl.Application.PlayerBehaviors.Commands;

namespace PumpingControl.Application.PlayerBehaviors.Validators;

public class UpdatePointsFromPlayerCommandValidator : AbstractValidator<UpdatePlayerPointsCommand>
{
    public UpdatePointsFromPlayerCommandValidator()
    {
        RuleFor(x => x.PlayerId)
            .NotEmpty();

        RuleFor(x => x.Points)
            .GreaterThan(0);
    }
}