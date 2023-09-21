using System.Text.Json.Serialization;

namespace PumpingControl.Domain;

public class Player : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string BusinessUnit { get; set; }
    public decimal Balance { get; set; }
    public Guid NationId { get; set; }
    [JsonIgnore] public Nation Nation { get; set; }
}