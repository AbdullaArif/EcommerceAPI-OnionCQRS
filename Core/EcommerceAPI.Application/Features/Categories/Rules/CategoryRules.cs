using EcommerceAPI.Application.Bases;
using EcommerceAPI.Application.Features.Categories.Exceptions;
using EcommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Rules
{
    public class CategoryRules: BaseRules
    {
        public Task CategoryMustBeUnique(string requestName, IList<Category> categories)
        {
            if (categories.Any(x => x.Name == requestName)) throw new CategoryMustBeUniqueException();
            return Task.CompletedTask;
        }
    }
}
