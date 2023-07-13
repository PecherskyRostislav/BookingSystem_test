using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationsApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
