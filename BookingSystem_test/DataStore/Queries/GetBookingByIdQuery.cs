using API.DataStore.Models;
using MediatR;

public record GeBookingByIdQuery(Guid id) : IRequest<Booking>;