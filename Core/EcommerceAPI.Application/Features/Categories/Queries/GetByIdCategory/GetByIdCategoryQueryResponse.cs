using EcommerceAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryResponse
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priorty { get; set; }

        public IList<DetailDto> Details { get; set; }
    }
}
