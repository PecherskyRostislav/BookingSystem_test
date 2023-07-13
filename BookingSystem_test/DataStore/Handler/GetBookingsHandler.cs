using MediatR;
using API.DataStore.Queries;
using API.DataStore.Models;

namespace API.DataStore.Handler;

public class GetBookingsHandler : IRequestHandler<GetBookingsQuery, IEnumerable<Booking>>
{
    private readonly ContextDb _contextDb;

    public GetBookingsHandler(ContextDb context)
    {
        _contextDb = context;
    }
    public async Task<IEnumerable<Booking>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
    {
        return _contextDb.Bookings;
    }
}
