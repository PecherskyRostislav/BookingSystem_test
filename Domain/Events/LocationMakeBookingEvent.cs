namespace Domain.Events;

public class LocationMakeBookingEvent : DomainEvent
{
    public LocationMakeBookingEvent(DateTime date, TimeSpan time, string goods, string carrier)
    {
        Date = date;
        Time = time;
        Goods = goods;
        Carrier = carrier;
    }

    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string Goods { get; set; }
    public string Carrier { get; set; }

}
