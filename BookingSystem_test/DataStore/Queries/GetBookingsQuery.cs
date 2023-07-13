using API.DataStore.Models;
using MediatR;

namespace API.DataStore.Queries;

public record GetBookingsQuery() : IRequest<IEnumerable<Booking>>;