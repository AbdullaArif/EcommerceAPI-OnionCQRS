using EcommerceAPI.Application.Features.Emails.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result)
                return Ok(new { Message = "Email sent successfully!" });

            return BadRequest(new { Message = "Failed to send email." });
        }
    }
}
