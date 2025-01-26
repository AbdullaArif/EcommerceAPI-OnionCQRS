using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Queries.GetByIdDetail
{
    public class GetByIdDetailQueryRequest:IRequest<GetByIdDetailQueryResponse>
    {
        public  int  Id { get; set; }
        public GetByIdDetailQueryRequest(int id)
        {
            Id = id;
        }

    }
}
 