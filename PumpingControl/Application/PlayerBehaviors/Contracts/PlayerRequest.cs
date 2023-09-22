namespace PumpingControl.Application.NationBehaviors.Contracts;

public record PlayerRequest(
    string Name,
    string Email,
    string BusinessUnit,
    Guid NationId
);