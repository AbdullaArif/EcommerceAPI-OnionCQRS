using EcommerceAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Queries.SearchDetails
{
    public class SearchDetailsQueryRequest:IRequest<IList<SearchDetailsQueryResponse>>
    {
        public string? Tittle { get; set; }
        public string? Description { get; set; }
        public CategoryDto? CategoryDto { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
