using EcommerceAPI.Application.Bases;
using EcommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Brands.Rules
{
    public class BrandRules: BaseRules
    {
        public Task BrandMustBeUnique(string brandName, IList<Brand> brands)
        {
            if (brands.Any(b => b.Name == brandName)) throw new BrandMustBeUniqueException();
            return Task.CompletedTask;
        }
    }
}
