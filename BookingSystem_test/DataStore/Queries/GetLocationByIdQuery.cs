using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Queries;

public record GetLocationByIdQuery(Guid Id) : IRequest<Location>;