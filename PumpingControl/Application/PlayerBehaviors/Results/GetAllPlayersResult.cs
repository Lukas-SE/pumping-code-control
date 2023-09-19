using PumpingControl.Domain;

namespace PumpingControl.Application.PlayerBehaviors.Results;

public record GetAllPlayersResult(List<Player> Players);