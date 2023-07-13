using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Commands;

public record PutLocationCommand(Guid id, Location Location) : IRequest<Location>;