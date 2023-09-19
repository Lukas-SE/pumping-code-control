using ErrorOr;
using MediatR;
using PumpingControl.Application.NationBehaviors.Commands;
using PumpingControl.Data.Repositories;
using PumpingControl.Domain;

namespace PumpingControl.Application.NationBehaviors.Handlers;

public class CreateNewNationCommandHandler : IRequestHandler<CreateNewNationCommand, ErrorOr<Nation>>
{
    private readonly INationRepository _nationRepository;

    public CreateNewNationCommandHandler(INationRepository nationRepository)
    {
        _nationRepository = nationRepository;
    }

    public async Task<ErrorOr<Nation>> Handle(CreateNewNationCommand request, CancellationToken cancellationToken)
    {
        var existentNation = await _nationRepository.GetByNameAsync(request.Name);

        if (existentNation is not null)
            return Error.Conflict();
        
        var newNation = new Nation
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        try
        {
            await _nationRepository.AddAsync(newNation);
        }
        catch (Exception e)
        {
            return Error.Failure(e.Message);
        }

        return newNation;
    }
}