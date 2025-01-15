using EcommerceAPI.Application.Features.Categories.Command.CreateCategory;
using EcommerceAPI.Application.Features.Categories.Command.DeleteCategory;
using EcommerceAPI.Application.Features.Categories.Command.UpdateCategory;
using EcommerceAPI.Application.Features.Categories.Queries.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
