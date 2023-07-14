using API.DataStore.Models;
using API.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.DataStore.Handler;

public class GeBookingByIdHandler : IRequestHandler<GeBookingByIdQuery, Booking>
{
    private readonly ContextDb _contextDb;
    public GeBookingByIdHandler(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<Booking> Handle(GeBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await _contextDb.Bookings
            .FirstOrDefaultAsync(booking => booking.Id == request.id, cancellationToken);

        if (booking is null)
        {
            throw new BookingNotFoundException(request.id);
        }

        return booking;
    }
}