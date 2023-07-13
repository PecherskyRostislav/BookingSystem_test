using API.DataStore.Commands;
using API.DataStore.Models;
using MediatR;

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
        var Location = await _contextDb.Locations.FindAsync(request.id, cancellationToken);
        if (Location == null) return null;

        Location.Name = request.Location.Name;
        Location.Address = request.Location.Address;
        Location.Capacity = request.Location.Capacity;

        _contextDb.Locations.Update(Location);
        await _contextDb.SaveChangesAsync();

        return Location;
    }
}