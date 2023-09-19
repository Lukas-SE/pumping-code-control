using FluentValidation;
using PumpingControl.Application.PlayerBehaviors.Queries;

namespace PumpingControl.Application.PlayerBehaviors.Validators;

public class GetPlayerQueryValidator : AbstractValidator<GetPlayerQuery>
{
    public GetPlayerQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}