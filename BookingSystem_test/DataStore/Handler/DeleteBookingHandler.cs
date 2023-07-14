using API.DataStore.Commands;
using API.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.DataStore.Handler;

public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, bool?>
{
    private readonly ContextDb _contextDb;
    public DeleteBookingHandler(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<bool?> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await _contextDb.Bookings
            .FirstOrDefaultAsync(booking => booking.Id == request.id, cancellationToken);

        if (booking is null)
        {
            throw new BookingNotFoundException(request.id);
        }

        var result = _contextDb.Bookings.Remove(booking);

        await _contextDb.SaveChangesAsync();
        return result.State == EntityState.Detached;
    }
}