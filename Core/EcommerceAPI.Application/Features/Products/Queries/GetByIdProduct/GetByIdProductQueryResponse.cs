using EcommerceAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public  int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public BrandDto Brand { get; set; }
    }
}
