using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Handler;

public class GeBookingByIdHandler : IRequestHandler<GeBookingByIdQuery, Booking>
{
    private readonly ContextDb _contextDb;
    public GeBookingByIdHandler(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<Booking> Handle(GeBookingByIdQuery request, CancellationToken cancellationToken) => 
        await _contextDb.Bookings.FindAsync(request.id);
}