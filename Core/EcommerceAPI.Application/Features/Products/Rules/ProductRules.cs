using EcommerceAPI.Application.Bases;
using EcommerceAPI.Application.Features.Products.Exceptions;
using EcommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Products.Rules
{
    public class ProductRules: BaseRules
    {
        public Task ProductTittleMust(string requestTiitle, IList<Product> products)
        {
            if (products.Any(x=>x.Tittle == requestTiitle)) throw new ProductTittleMustException();
            return Task.CompletedTask;
        }
    }
}
