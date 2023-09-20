using Application.Features;
using Application.Features.Category.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategories query)
        {
            GetCategoriesResponse response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
