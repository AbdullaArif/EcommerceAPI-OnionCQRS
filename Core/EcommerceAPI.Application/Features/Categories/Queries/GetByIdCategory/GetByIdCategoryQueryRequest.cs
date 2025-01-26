using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest: IRequest<GetByIdCategoryQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
