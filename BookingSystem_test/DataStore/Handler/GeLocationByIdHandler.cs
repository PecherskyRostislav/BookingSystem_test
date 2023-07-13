using API.DataStore.Models;
using API.DataStore.Queries;
using MediatR;

namespace API.DataStore.Handler;

public class GeLocationByIdHandler : IRequestHandler<GetLocationByIdQuery, Location>
{
    private readonly ContextDb _contextDb;
    public GeLocationByIdHandler(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<Location> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken) => await _contextDb.Locations.FindAsync(request.Id);
}