using EcommerceAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Products.Exceptions
{
    public class ProductTittleMustException: BaseException
    {
        public ProductTittleMustException(): base("Tittle uniq olmalidir")
        {
            
        }
    }
}
