using API.DataStore.Commands;
using MediatR;

namespace API.DataStore.Handler;

public class AddBookingHandler : IRequestHandler<AddBookingCommand>
{
    private readonly ContextDb _contextDb;

    public AddBookingHandler(ContextDb context)
    {
        _contextDb = context;
    }

    public async Task Handle(AddBookingCommand request, CancellationToken cancellationToken)
    {
        await _contextDb.Bookings.AddAsync(request.Booking);
        return;
    }
}
