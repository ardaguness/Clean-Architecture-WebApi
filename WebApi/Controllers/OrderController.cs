using Application.Features.Order.OrderQueries;
using Application.Features;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Order.OrderCommands;
using System.Net;

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
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromQuery] CreateOrder command)
        {
            CreateOrderResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
