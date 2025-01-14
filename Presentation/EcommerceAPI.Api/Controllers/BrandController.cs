using EcommerceAPI.Application.Features.Brands.Command.CreateBrand;
using EcommerceAPI.Application.Features.Brands.Command.UpdateBrand;
using EcommerceAPI.Application.Features.Brands.Queries.GetAllBrands;
using EcommerceAPI.Application.Features.Products.Command.DeleteProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await _mediator.Send(new GetAllBrandsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut] 
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
