using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Products.Queries.SearchProducts
{
    public class SearchProductsQueryResponse
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string BrandName { get; set; }
    }
}
