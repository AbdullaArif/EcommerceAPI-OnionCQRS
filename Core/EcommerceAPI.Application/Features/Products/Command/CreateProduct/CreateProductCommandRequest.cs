﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandRequest:IRequest
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public int BrandId { get; set; }

        public IList<int> CategoryIds { get; set; }

    }
}
