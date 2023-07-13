using Domain.Entities.Location;

namespace Domain.Events;

public class LocationProcessBookingEvent : DomainEvent
{
    public LocationProcessBookingEvent(long bookingId)
    {
        BookingId = bookingId;
    }

    public long BookingId { get; set; }
    public Booking? booking { get; set; }
}
