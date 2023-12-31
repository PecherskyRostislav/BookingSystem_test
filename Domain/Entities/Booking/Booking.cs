﻿
using Domain.Base;

namespace Domain.Entities.Location;

public  class Booking : BaseEntity
{
    public Booking(long bookingId, long locationId, DateTime date, TimeSpan time, string goods, string carrier, string state)
    {
        Id = bookingId;
        LocationId = locationId;
        Date = date;
        Time = time;
        Goods = goods;
        Carrier = carrier;
        State = state;
    }

    public DateTime Date { get; private set; }
    public TimeSpan Time { get; private set; }
    public string Goods { get; private set; }
    public long LocationId { get; private set; }
    public Location? Location { get; private set; }
    public string Carrier { get; private set; }
    public string State { get; private set; }
}
