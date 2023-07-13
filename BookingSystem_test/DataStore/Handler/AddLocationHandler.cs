using API.DataStore.Commands;
using MediatR;

namespace API.DataStore.Handler;

public class AddLocationHandler : IRequestHandler<AddLocationCommand>
{
    private readonly ContextDb _contextDb;

    public AddLocationHandler(ContextDb context)
    {
        _contextDb = context;
    }

    public async Task Handle(AddLocationCommand request, CancellationToken cancellationToken)
    {
        await _contextDb.Locations.AddAsync(request.Location);
        return;
    }
}
