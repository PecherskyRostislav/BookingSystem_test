using MediatR;

namespace API.DataStore.Commands;

public record DeleteLocationCommand(Guid id) : IRequest<bool>;
