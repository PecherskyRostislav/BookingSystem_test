using MediatR;

namespace API.DataStore.Commands;

public record DeleteBookingCommand(Guid id) : IRequest<bool?>;
