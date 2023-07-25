using Flunt.Notifications;

namespace Store.Shared.Entities;

public abstract class Entity : Notifiable
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
}