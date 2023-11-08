using Application.Features;
using Application.Features.Product.ProductCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.SignalR.HubServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        readonly IProductHubService _productHubService;
        public ProductController(IMediator mediator, IProductHubService productHubService)
        {
            _mediator = mediator;
            _productHubService = productHubService;
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

            await _productHubService.ProductAddedMessageAsync($"Product named {query.Name} has been added.");

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct query)
        {
            UpdateProductResponse response = await _mediator.Send(query);

            await _productHubService.ProductAddedMessageAsync($"{query.Name} isminde ürün eklenmiştir.");

            await _productHubService.ProductAddedMessageAsync($"Product named {query.Name} has been updated.");

            return Ok(response);
        }
        [HttpDelete("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct([FromQuery] DeleteCommand query)
        {
            DeleteCommandResponse response = await _mediator.Send(query);
            await _productHubService.ProductAddedMessageAsync($"Product with id {query.Id} removed.");
            return Ok(response);
        }
    }
}