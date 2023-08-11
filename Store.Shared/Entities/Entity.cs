using Flunt.Notifications;

namespace Store.Shared.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public const double BRAZILIAN_UCT = -3;
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
}