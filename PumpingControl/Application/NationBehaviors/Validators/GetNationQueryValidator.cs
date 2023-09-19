using FluentValidation;
using PumpingControl.Application.NationBehaviors.Queries;

namespace PumpingControl.Application.NationBehaviors.Validators;

public class GetNationQueryValidator: AbstractValidator<GetNationQuery>
{
    public GetNationQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}