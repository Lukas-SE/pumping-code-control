using System.Text.Json.Serialization;

namespace PumpingControl.Domain;

public class Nation : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore] public List<Player> Players { get; set; }
}