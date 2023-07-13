using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Commands;

public record PutBookingCommand(Guid id, Booking Booking) : IRequest<Booking>;