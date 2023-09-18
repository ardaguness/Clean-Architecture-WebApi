using Application.Features.Product.ProductCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> ProductList([FromQuery] GetProducts query)
        {
            GetProductsResponse response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}