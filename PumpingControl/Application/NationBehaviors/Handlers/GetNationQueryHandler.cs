using ErrorOr;
using MediatR;
using PumpingControl.Application.NationBehaviors.Queries;
using PumpingControl.Data.Repositories;
using PumpingControl.Domain;

namespace PumpingControl.Application.NationBehaviors.Handlers;

public class GetNationQueryHandler : IRequestHandler<GetNationQuery, ErrorOr<Nation>>
{
    private readonly INationRepository _nationRepository;

    public GetNationQueryHandler(INationRepository nationRepository)
    {
        _nationRepository = nationRepository;
    }

    public async Task<ErrorOr<Nation>> Handle(GetNationQuery request, CancellationToken cancellationToken)
    {
        var nation = await _nationRepository.GetByIdAsync(request.Id);

        if (nation is null) 
            return Error.NotFound();

        return nation;
    }
}