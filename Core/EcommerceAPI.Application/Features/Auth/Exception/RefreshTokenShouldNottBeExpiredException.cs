using EcommerceAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Auth.Exception
{
    public class RefreshTokenShouldNottBeExpiredException : BaseException
    {
        public RefreshTokenShouldNottBeExpiredException() : base("Aktual qalmaq muddetiniz sona catmistir. Zehmet olmazsa yeniden Login olun :)") { }
    }
}
