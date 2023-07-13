namespace API.DataStore.Models;

public class Location : BaseEntity
{
    public Location()
    {
        
    }

    public string Name { get; private set; }
    public string Address { get; private set; }
    public int Capacity { get; private set; }
}
