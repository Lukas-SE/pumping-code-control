using ErrorOr;
using MediatR;
using PumpingControl.Application.NationBehaviors.Queries;
using PumpingControl.Application.NationBehaviors.Results;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.NationBehaviors.Handlers;

public class GetNationQueryHandler : IRequestHandler<GetNationQuery, ErrorOr<NationResult>>
{
    private readonly INationRepository _nationRepository;

    public GetNationQueryHandler(INationRepository nationRepository)
    {
        _nationRepository = nationRepository;
    }

    public async Task<ErrorOr<NationResult>> Handle(GetNationQuery request, CancellationToken cancellationToken)
    {
        var nation = await _nationRepository.GetByIdAsync(request.Id, "Players");

        if (nation is null) 
            return Error.NotFound();
        
        return new NationResult(nation.Id, nation.Name, nation.Players.Sum(x => x.Balance));
    }
}