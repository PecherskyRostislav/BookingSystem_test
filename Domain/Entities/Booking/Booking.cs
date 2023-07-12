﻿
namespace Domain.Entities.Location;

public  class Booking
{
    public Booking()
    {
        
    }

    public DateTime Date { get; private set; }
    public TimeSpan Time { get; private set; }
    public string Goods { get; private set; }
    public Location Location { get; private set; }
    public string Carrier { get; private set; }
    public string State { get; private set; }
}
