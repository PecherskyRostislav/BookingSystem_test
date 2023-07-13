using API.DataStore.Commands;
using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Handler;

public class AddBookingHandler : IRequestHandler<AddBookingCommand, Booking>
{
    private readonly ContextDb _contextDb;

    public AddBookingHandler(ContextDb context)
    {
        _contextDb = context;
    }

    public async Task<Booking> Handle(AddBookingCommand request, CancellationToken cancellationToken) 
    {
        await _contextDb.Bookings.AddAsync(request.Booking, cancellationToken);

        return request.Booking;
    }
}
