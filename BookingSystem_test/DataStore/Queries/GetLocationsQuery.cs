using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Queries;

public record GetLocationsQuery() : IRequest<IEnumerable<Location>>;