using System.ComponentModel;
using ErrorOr;
using MediatR;
using PumpingControl.Application.Common.Enums;
using PumpingControl.Application.NationBehaviors.Queries;
using PumpingControl.Application.NationBehaviors.Results;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Application.NationBehaviors.Handlers;

public class GetAllNationsQueryHandler : IRequestHandler<GetAllNationsQuery, ErrorOr<List<NationResult>>>
{
    private readonly INationRepository _nationRepository;

    public GetAllNationsQueryHandler(INationRepository nationRepository)
    {
        _nationRepository = nationRepository;
    }

    public async Task<ErrorOr<List<NationResult>>> Handle(GetAllNationsQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var nations = await _nationRepository.GetAllAsync("Players");

            if (nations is null) return Error.Unexpected();

            var response = nations.Select(x =>
                new NationResult(x.Id, x.Name, x.Players.Sum(x => x.Balance))).ToList();

            if (request.Parameter != null) response = SortNations(response, request.Parameter);

            return response;
        }
        catch (InvalidEnumArgumentException)
        {
            return Error.Unexpected();
        }

    }
    
    public List<NationResult> SortNations(List<NationResult> nations, OrderByParameter? param)
    {
        List<NationResult>? data;
        switch (param)
        {
            case OrderByParameter.Score: return data = nations.OrderByDescending(x => x.Score).ToList();
            case OrderByParameter.Name: return data = nations.OrderBy(x => x.Name).ToList();
            default: throw new InvalidEnumArgumentException();
        }
    }
}