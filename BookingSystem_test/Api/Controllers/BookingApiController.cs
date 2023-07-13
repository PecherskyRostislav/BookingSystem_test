using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingApiController(IMediator mediator)
        {
                _mediator = mediator;
        }
    }
}
