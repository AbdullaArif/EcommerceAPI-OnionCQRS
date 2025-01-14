using EcommerceAPI.Application.Features.Details.Command.CreateDetail;
using EcommerceAPI.Application.Features.Details.Command.DeleteDetail;
using EcommerceAPI.Application.Features.Details.Command.UpdateDetail;
using EcommerceAPI.Application.Features.Details.Queries.GetAllDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DetailController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDetails()
        {
            var response = await _mediator.Send(new GetAllDetailQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetail(CreateDetailCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDetail(UpdateDetailCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDetail(DeleteDetailCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
