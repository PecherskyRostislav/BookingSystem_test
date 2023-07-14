using API.DataStore.Commands;
using API.DataStore.Models;
using API.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.DataStore.Handler;

public class PutLocationHandler : IRequestHandler<PutLocationCommand, Location>
{
    public readonly ContextDb _contextDb;
    public PutLocationHandler(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    public async Task<Location> Handle(PutLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _contextDb.Locations
            .FirstOrDefaultAsync(location => location.Id == request.id, cancellationToken);

        if (location is null)
        {
            throw new LocationNotFoundException(request.id);
        }

        location.Name = request.Location.Name;
        location.Address = request.Location.Address;
        location.Capacity = request.Location.Capacity;

        _contextDb.Locations.Update(location);
        await _contextDb.SaveChangesAsync();

        return location;

    }
}