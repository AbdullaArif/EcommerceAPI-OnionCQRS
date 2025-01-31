using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Command.CreateDetail
{
    public class CreateDetailCommandValidator:AbstractValidator<CreateDetailCommandRequest>
    {
        public CreateDetailCommandValidator()
        {
            RuleFor(x => x.Tittle)
                 .NotEmpty();

            RuleFor(x => x.Description)
               .NotEmpty();

            RuleFor(x=>x.CategoryId).GreaterThan(0);

        }
    }
}
