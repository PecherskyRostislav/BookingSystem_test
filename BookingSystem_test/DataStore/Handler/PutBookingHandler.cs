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

        booking.LocationId = request.Booking.LocationId;
        booking.Date = request.Booking.Date;
        booking.Time = request.Booking.Time;
        booking.State = request.Booking.State;
        booking.Goods = request.Booking.Goods;
        booking.Carrier = request.Booking.Carrier;


        _contextDb.Bookings.Update(booking);
        await _contextDb.SaveChangesAsync();

        return booking;
    }
}
