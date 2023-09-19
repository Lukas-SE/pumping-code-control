using FluentValidation;
using PumpingControl.Application.NationBehaviors.Commands;

namespace PumpingControl.Application.NationBehaviors.Validators;

public class CreateNewNationCommandValidator : AbstractValidator<CreateNewNationCommand>
{
    public CreateNewNationCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}