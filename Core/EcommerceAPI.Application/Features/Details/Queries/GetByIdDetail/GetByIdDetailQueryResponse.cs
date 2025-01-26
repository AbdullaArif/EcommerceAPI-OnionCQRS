using EcommerceAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Queries.GetByIdDetail
{
    public class GetByIdDetailQueryResponse
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }

        public CategoryDto Category { get; set; }
    }
}
