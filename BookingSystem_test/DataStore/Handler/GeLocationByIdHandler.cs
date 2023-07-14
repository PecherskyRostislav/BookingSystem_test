using API.DataStore.Models;
using API.DataStore.Queries;
using API.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.DataStore.Handler;

public class GeLocationByIdHandler : IRequestHandler<GetLocationByIdQuery, Location>
{
    private readonly ContextDb _contextDb;
    public GeLocationByIdHandler(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<Location> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var location = await _contextDb.Locations
            .FirstOrDefaultAsync(location => location.Id == request.Id, cancellationToken);

        if (location is null)
        {
            throw new LocationNotFoundException(request.Id);
        }

        return location;
    }
}