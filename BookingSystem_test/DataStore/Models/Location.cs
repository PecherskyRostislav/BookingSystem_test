namespace API.DataStore.Models;

public class Location : BaseEntity
{
    public Location()
    {
        
    }

    public string Name { get; set; }
    public string Address { get; set; }
    public int Capacity { get; set; }
}
