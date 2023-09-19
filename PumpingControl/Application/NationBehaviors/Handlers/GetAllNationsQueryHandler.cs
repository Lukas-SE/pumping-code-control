using ErrorOr;
using MediatR;
using PumpingControl.Application.NationBehaviors.Queries;
using PumpingControl.Application.NationBehaviors.Results;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.NationBehaviors.Handlers;

public class GetAllNationsQueryHandler : IRequestHandler<GetAllNationsQuery, ErrorOr<GetAllNationsResult>>
{
    private readonly INationRepository _nationRepository;

    public GetAllNationsQueryHandler(INationRepository nationRepository)
    {
        _nationRepository = nationRepository;
    }

    public async Task<ErrorOr<GetAllNationsResult>> Handle(GetAllNationsQuery request,
        CancellationToken cancellationToken)
    {
        var nations = await _nationRepository.GetAllAsync();

        if (nations is null) return Error.Unexpected();

        return new GetAllNationsResult(nations);
    }
}