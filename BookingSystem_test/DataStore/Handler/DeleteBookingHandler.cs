﻿using API.DataStore.Commands;
using MediatR;

namespace API.DataStore.Handler;

public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, bool>
{
    private readonly ContextDb _contextDb;
    public DeleteBookingHandler(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await _contextDb.Bookings.FindAsync(request.id, cancellationToken);
        if (booking == null) return false;

        var result = _contextDb.Bookings.Remove(booking);

        return result.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
    }
}