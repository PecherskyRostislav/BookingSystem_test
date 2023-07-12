namespace Domain.Entities.Location;

public class Location
{
    public Location()
    {
            
    }

    public string Name { get; private set; }
    public string Address { get; private set; }
    public int Capacity { get; private set; }
}
