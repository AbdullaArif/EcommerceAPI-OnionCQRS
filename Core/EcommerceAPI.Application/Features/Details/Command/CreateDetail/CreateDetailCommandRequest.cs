using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Command.CreateDetail
{
    public class CreateDetailCommandRequest:IRequest<Unit>
    {

        public string Tittle { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
