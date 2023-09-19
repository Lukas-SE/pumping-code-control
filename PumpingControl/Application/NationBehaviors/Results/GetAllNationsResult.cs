using PumpingControl.Domain;

namespace PumpingControl.Application.NationBehaviors.Results;

public record GetAllNationsResult(List<Nation> Nations);