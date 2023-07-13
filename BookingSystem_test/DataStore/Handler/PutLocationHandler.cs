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

        request.Location.Id = Location.Id;
        _contextDb.Locations.Update(request.Location);

        return request.Location;
    }
}