namespace API.DataStore.Models;

public  class Booking : BaseEntity
{
    public Booking()
    {
    }

    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string Goods { get; set; }
    public Guid LocationId { get; set; }
    public Location? Location { get; set; }
    public string Carrier { get; set; }
    public string State { get; set; }
}
