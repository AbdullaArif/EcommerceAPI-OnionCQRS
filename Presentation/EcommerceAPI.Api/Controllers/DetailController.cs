﻿using EcommerceAPI.Application.Features.Details.Command.CreateDetail;
using EcommerceAPI.Application.Features.Details.Command.DeleteDetail;
using EcommerceAPI.Application.Features.Details.Command.UpdateDetail;
using EcommerceAPI.Application.Features.Details.Queries.GetAllDetails;
using EcommerceAPI.Application.Features.Details.Queries.GetByIdDetail;
using EcommerceAPI.Application.Features.Details.Queries.SearchDetails;
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
            IList<GetAllDetailQueryResponse> response = await _mediator.Send(new GetAllDetailQueryRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdDetail(int id)
        {
            var response = await _mediator.Send(new GetByIdDetailQueryRequest(id));
            return Ok(response);
        }

        [HttpGet]
        public  async Task<IActionResult> SearchDetails([FromQuery] SearchDetailsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
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
