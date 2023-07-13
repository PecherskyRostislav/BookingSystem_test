using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Commands;

public record AddBookingCommand(Booking Booking) : IRequest<Booking>;