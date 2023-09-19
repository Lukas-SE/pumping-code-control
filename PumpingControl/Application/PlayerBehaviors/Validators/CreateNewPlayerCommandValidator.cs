using FluentValidation;
using PumpingControl.Application.PlayerBehaviors.Commands;

namespace PumpingControl.Application.PlayerBehaviors.Validators;

public class CreateNewPlayerCommandValidator : AbstractValidator<CreateNewPlayerCommand>
{
    public CreateNewPlayerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.BusinessUnit)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.InitialBalance)
            .GreaterThanOrEqualTo(0);
    }
}