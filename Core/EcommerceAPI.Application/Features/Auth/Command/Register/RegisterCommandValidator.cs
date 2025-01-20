using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator: AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x=>x.FullName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(35)
                .WithName("Ad Soyad");
                

            RuleFor(x=>x.Email).NotEmpty()
                .MinimumLength(8)
                .MaximumLength(65)
                .EmailAddress()
                .WithName("Email adres");


            RuleFor(x=>x.Password).NotEmpty()
                .MinimumLength(3)
                .MaximumLength(65)
                .WithName("Sifre");


            RuleFor(x=>x.ConfirmPasword).NotEmpty()
                .MinimumLength(6)
                .Equal(x=>x.Password)
                .WithName("Tekrar Sifre");

        }
    }
}
