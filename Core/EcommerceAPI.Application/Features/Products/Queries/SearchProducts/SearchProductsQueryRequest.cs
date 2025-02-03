using EcommerceAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Products.Queries.SearchProducts
{
    public class SearchProductsQueryRequest : IRequest<IList<SearchProductsQueryResponse>>
    {
        public string? Tittle { get; set; }
        public string? Description { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public BrandDto? Brand { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
