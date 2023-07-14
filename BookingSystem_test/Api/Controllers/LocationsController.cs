using API.DataStore.Commands;
using API.DataStore.Models;
using API.DataStore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers;

/// <summary>
/// The Locations controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationsController"/> class.
    /// </summary>
    /// <param name="mediator"></param>
    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Location>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetLocationsQuery()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Location), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(Guid id)
    {
        return Ok(await _mediator.Send(new GetLocationByIdQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Location), StatusCodes.Status201Created)]
    public async Task<ActionResult> Post([FromBody] Location body)
    {
        var location = await _mediator.Send(new AddLocationCommand(body));

        return CreatedAtAction(nameof(Post), new { id = location.Id }, location);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] Location body)
    {
        return Ok(await _mediator.Send(new PutLocationCommand(id, body)));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return Ok(await _mediator.Send(new DeleteLocationCommand(id)));
    }
}
