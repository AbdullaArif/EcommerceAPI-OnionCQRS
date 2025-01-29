using EcommerceAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Exceptions
{
    public class CategoryMustBeUniqueException:BaseException
    {
        public CategoryMustBeUniqueException():base("Category Name unikal olmalidir")
        {    
        }
    }
}
