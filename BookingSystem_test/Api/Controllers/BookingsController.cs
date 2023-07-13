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
    public async Task<ActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetBookingsQuery()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var item = await _mediator.Send(new GeBookingByIdQuery(id));
        if (item == null) 
        {
            return NotFound(id);
        }

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Booking body)
    {
        return Ok(await _mediator.Send(new AddBookingCommand(body)));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] Booking body)
    {
        var item = await _mediator.Send(new PutBookingCommand(id, body));
        if (item == null)
        {
            return NotFound(id);
        }

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var item = await _mediator.Send(new DeleteBookingCommand(id));
        if (item == null)
        {
            return NotFound(id);
        }

        return Ok(item);
    }
}
