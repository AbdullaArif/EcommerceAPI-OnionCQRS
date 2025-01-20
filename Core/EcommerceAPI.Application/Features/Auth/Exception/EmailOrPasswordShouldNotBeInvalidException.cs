using EcommerceAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Auth.Exception
{
    public class EmailOrPasswordShouldNotBeInvalidException: BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException():base("Istifadeci veya sifre sehvdir") { }
    }
}
