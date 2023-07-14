using API.DataStore.Commands;
using API.DataStore.Models;
using API.DataStore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IMediator _mediator;
    public BookingsController(IMediator mediator)
    {
            _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Booking>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetBookingsQuery()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(Guid id)
    {
        return Ok(await _mediator.Send(new GeBookingByIdQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Location), StatusCodes.Status201Created)]
    public async Task<ActionResult> Post([FromBody] Booking body)
    {
        var booking = await _mediator.Send(new AddBookingCommand(body));

        return CreatedAtAction(nameof(Post), new { id = booking.Id }, booking);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] Booking body)
    {
        return Ok(await _mediator.Send(new PutBookingCommand(id, body)));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return Ok(await _mediator.Send(new DeleteBookingCommand(id)));
    }
}
