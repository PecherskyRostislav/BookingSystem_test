namespace Domain;

public interface IHasDomainEvent
{
    public List<DomainEvent> DomainEvents { get; set; }
}