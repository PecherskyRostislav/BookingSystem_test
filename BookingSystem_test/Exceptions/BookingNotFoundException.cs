namespace API.Exceptions;

public class BookingNotFoundException : NotFoundException
{
    public BookingNotFoundException(Guid bookingId)
        : base($"Booking with the identifier {bookingId} was not found.")
    {
    }
}
