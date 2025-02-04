using EcommerceAPI.Application.Interfaces.Emails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Emails.Command
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommandRequest, bool>
    {
        private readonly IEmailService _emailService;

        public SendEmailCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<bool> Handle(SendEmailCommandRequest request, CancellationToken cancellationToken)
        {
            await _emailService.SendEmailAsync(request.To, request.Subject, request.Body);
            return true;
        }
    }
}
