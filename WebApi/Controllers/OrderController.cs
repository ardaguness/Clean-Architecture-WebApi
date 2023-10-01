using Application.Features.Order.OrderQueries;
using Application.Features;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrders query)
        {
            GetOrdersResponse response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
