using Application.Features;
using Application.Features.Product.ProductCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetProducts")]
        public async Task<IActionResult> ProductList([FromQuery] GetProducts query)
        {
            GetProductsResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("GetProductsByCategoryId")]
        public async Task<IActionResult> GetProductsByCategoryId([FromQuery] GetProductsByCategoryId query)
        {
            GetProductsByCategoryIdResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById([FromQuery] GetProductById query)
        {
            GetProductByIdResponse response = await _mediator.Send(query);
            return Ok(response);
        }
        
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct query)
        {
            CreateProductResponse response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct query)
        {
            UpdateProductResponse response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpDelete("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct([FromQuery] DeleteCommand query)
        {
            DeleteCommandResponse response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}