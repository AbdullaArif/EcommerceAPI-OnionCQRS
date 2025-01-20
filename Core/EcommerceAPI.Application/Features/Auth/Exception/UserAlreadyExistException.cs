using EcommerceAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Auth.Exception
{
    public class UserAlreadyExistException: BaseException
    {
        public UserAlreadyExistException(): base("Bu istifadeci onsuzda var!") { }
    }
}
