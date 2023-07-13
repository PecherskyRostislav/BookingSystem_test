using API.DataStore.Commands;
using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Handler;

public class AddLocationHandler : IRequestHandler<AddLocationCommand, Location>
{
    private readonly ContextDb _contextDb;

    public AddLocationHandler(ContextDb context)
    {
        _contextDb = context;
    }

    public async Task<Location> Handle(AddLocationCommand request, CancellationToken cancellationToken)
    {
        await _contextDb.Locations.AddAsync(request.Location, cancellationToken);
        await _contextDb.SaveChangesAsync();
        return request.Location;
    }
}
