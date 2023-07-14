using API.DataStore.Commands;
using API.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.DataStore.Handler;

public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, bool?>
{
    private readonly ContextDb _contextDb;
    public DeleteLocationHandler(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<bool?> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _contextDb.Locations
            .FirstOrDefaultAsync(location => location.Id == request.id, cancellationToken);

        if (location is null)
        {
            throw new LocationNotFoundException(request.id);
        }
        var result = _contextDb.Locations.Remove(location);

        await _contextDb.SaveChangesAsync();
        return result.State == EntityState.Detached;
    }
}