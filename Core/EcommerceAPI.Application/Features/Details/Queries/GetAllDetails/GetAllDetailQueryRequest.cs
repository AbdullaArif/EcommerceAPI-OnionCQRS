using EcommerceAPI.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Queries.GetAllDetails
{
    public class GetAllDetailQueryRequest:IRequest<IList<GetAllDetailQueryResponse>>
    {
   
    }
}
