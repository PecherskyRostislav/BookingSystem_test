using API.DataStore.Commands;
using API.DataStore.Models;
using API.DataStore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IMediator _mediator;
    public BookingController(IMediator mediator)
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
        return Ok(await _mediator.Send(new GetBookingsQuery()));
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] string body)
    {
        Booking Booking = new();
        JsonConvert.PopulateObject(body, Booking);
        await _mediator.Send(new AddBookingCommand(Booking));

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] string body)
    {
        return Ok(await _mediator.Send(new GetBookingsQuery()));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return Ok(await _mediator.Send(new GetBookingsQuery()));
    }
}
