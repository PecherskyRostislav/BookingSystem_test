using MediatR;
using API.DataStore.Queries;
using API.DataStore.Models;

namespace API.DataStore.Handler;

public class GetLocationsHandler : IRequestHandler<GetLocationsQuery, IEnumerable<Location>>
{
    private readonly ContextDb _contextDb;

    public GetLocationsHandler(ContextDb context)
    {
        _contextDb = context;
    }
    public async Task<IEnumerable<Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        return _contextDb.Locations;
    }
}
