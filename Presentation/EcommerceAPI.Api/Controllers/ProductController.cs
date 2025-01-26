using EcommerceAPI.Application.Features.Products.Command.CreateProduct;
using EcommerceAPI.Application.Features.Products.Command.DeleteProduct;
using EcommerceAPI.Application.Features.Products.Command.UpdateProduct;
using EcommerceAPI.Application.Features.Products.Queries.GetAllProducts;
using EcommerceAPI.Application.Features.Products.Queries.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProduct()
        {
            IList<GetAllProductsQueryResponse> response = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var response = await _mediator.Send(new GetByIdProductQueryRequest(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UptadeProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }


    }
}
