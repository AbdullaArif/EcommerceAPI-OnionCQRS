using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Command.DeleteDetail
{
    public class DeleteDetailCommandRequest:IRequest
    {
        public int Id { get; set; }
    }
}
