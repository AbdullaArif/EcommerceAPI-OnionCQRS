using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Emails.Command
{
    public class SendEmailCommandValidator: AbstractValidator<SendEmailCommandRequest>
    {
        public SendEmailCommandValidator() {
            RuleFor(x => x.To).NotEmpty().EmailAddress();
            RuleFor(x => x.Subject).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Body).NotEmpty();
        }
    }
}
