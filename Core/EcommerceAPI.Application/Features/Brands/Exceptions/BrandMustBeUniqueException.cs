using EcommerceAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Brands.Exceptions
{
    public class BrandMustBeUniqueException:BaseException
    {
        public BrandMustBeUniqueException():base("Brand adi unikal olmalidir")
        {
        }

    }
}
