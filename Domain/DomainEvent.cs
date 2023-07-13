using MediatR;

namespace Domain;

public class DomainEvent : INotification
{
    public DomainEvent()
    {
        DateOccurred = DateTime.UtcNow;
    }

    public bool IsPublished { get; set; }
    public DateTimeOffset DateOccurred { get; protected set; }
}
