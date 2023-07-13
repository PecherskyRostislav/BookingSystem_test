using API.DataStore.Commands;
using MediatR;

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
        var Location = await _contextDb.Locations.FindAsync(request.id, cancellationToken);
        if (Location == null) return null;

        var result = _contextDb.Locations.Remove(Location);

        await _contextDb.SaveChangesAsync();
        return result.State == Microsoft.EntityFrameworkCore.EntityState.Detached;
    }
}