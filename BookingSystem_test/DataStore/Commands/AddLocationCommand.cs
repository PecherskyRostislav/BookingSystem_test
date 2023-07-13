using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Commands;

public record AddLocationCommand(Location Location) : IRequest<Location>;