using PumpingControl.Domain;

namespace PumpingControl.Application.PlayerBehaviors.Results;

public record PlayerResult(
    Guid Id,
    string Name,
    string Email,
    string BusinessUnit,
    decimal Balance,
    Guid NationId
);