using API.DataStore.Commands;
using API.DataStore.Models;
using API.DataStore.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;
    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetLocationsQuery()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id)
    {
        return Ok(await _mediator.Send(new GetLocationByIdQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody]string body)
    {
        Location location = new();
        JsonConvert.PopulateObject(body, location);
        await _mediator.Send(new AddLocationCommand(location));

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] string body)
    {
        return Ok(await _mediator.Send(new GetLocationsQuery()));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return Ok(await _mediator.Send(new GetLocationsQuery()));
    }
}
