using EcommerceAPI.Application.DTOs;
using EcommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priorty { get; set; }

        public IList<DetailDto> Details { get; set; }
       
    }
}
