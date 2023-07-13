using Domain.Base;
using Domain.Events;

namespace Domain.Entities.Location;

public class Location : BaseEntity, IHasDomainEvent
{
    public Location(long locationId, string name, string address, int capacity)
    {
        Id = locationId;
        Name = name;
        Address = address;
        Capacity = capacity;
        DomainEvents = new List<DomainEvent>();
    }

    public string Name { get; private set; }
    public string Address { get; private set; }
    public int Capacity { get; private set; }
    public List<DomainEvent> DomainEvents { get; set; }
}
