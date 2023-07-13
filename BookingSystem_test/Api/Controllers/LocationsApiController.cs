using API.DataStore.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsApiController : ControllerBase
{
    private readonly IMediator _mediator;
    public LocationsApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetLocationsQuery()));
    }
}
