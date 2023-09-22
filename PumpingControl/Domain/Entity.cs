namespace PumpingControl.Domain;

public abstract class Entity: IEntity
{
    public Guid Id {get; init;}

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}