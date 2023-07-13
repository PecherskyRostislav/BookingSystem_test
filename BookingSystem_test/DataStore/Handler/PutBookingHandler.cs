using API.DataStore.Commands;
using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Handler;

public class PutBookingHandler : IRequestHandler<PutBookingCommand, Booking>
{
    public readonly ContextDb _contextDb;
    public PutBookingHandler(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    public async Task<Booking> Handle(PutBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await _contextDb.Bookings.FindAsync(request.id, cancellationToken);
        if (booking == null) return null;

        request.Booking.Id = booking.Id;
        _contextDb.Bookings.Update(request.Booking);

        return request.Booking;
    }
}
