﻿using API.DataStore.Commands;
using API.DataStore.Models;
using API.DataStore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        var item = await _mediator.Send(new GetLocationByIdQuery(id));
        if (item == null)
        {
            return NotFound(id);
        }

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Location body)
    {
        return Ok(await _mediator.Send(new AddLocationCommand(body)));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] Location body)
    {
        var item = await _mediator.Send(new PutLocationCommand(id, body));
        if (item == null)
        {
            return NotFound(id);
        }

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var item = await _mediator.Send(new DeleteLocationCommand(id));
        if (item == null)
        {
            return NotFound(id);
        }

        return Ok(item);
    }
}
