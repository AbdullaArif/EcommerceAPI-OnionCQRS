using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c=>c.Name).NotEmpty();
            RuleFor(c=>c.DetailIds).NotEmpty()
                .Must(c => c.Any());
        }
    }
}
