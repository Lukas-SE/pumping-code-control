using PumpingControl.Application.Common.Enums;

namespace PumpingControl.Application.PlayerBehaviors.Contracts;

public record UpdatePointsRequest(decimal Amount, PointsAction Action);