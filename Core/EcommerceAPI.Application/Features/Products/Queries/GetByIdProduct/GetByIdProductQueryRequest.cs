using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQueryRequest: IRequest<GetByIdProductQueryResponse>
    {
        public  int Id { get; set; }
        public GetByIdProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
