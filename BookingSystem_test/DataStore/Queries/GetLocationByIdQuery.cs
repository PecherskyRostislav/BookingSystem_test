using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Queries;

public record GetLocationByIdQuery(Guid id) : IRequest<Location>;