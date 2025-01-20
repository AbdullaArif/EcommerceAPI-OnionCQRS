using EcommerceAPI.Application.Bases;
using EcommerceAPI.Application.Features.Auth.Exception;
using EcommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }

        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool check)
        {
            if (user is null || !check) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask ;
        }
    }
}
