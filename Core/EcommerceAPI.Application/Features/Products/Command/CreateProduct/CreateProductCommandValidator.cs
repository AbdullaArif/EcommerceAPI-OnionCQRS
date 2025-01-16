using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator :AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Tittle)
                .NotEmpty();

            RuleFor(x => x.Description)
               .NotEmpty();

            RuleFor(x => x.BrandId)
               .GreaterThan(0);

            RuleFor(x => x.Price)
              .GreaterThan(0);


            RuleFor(x => x.Discount)
               .GreaterThanOrEqualTo(0);

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(c=>c.Any());

            

        }

    }
}
