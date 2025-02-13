﻿using EcommerceAPI.Application.DTOs;
using EcommerceAPI.Application.Interfaces.AutoMapper;
using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>()
                .GetAllAsync(p=> !p.IsDeleted,  include: x=>x.Include(b=>b.Brand) );

            BrandDto brand = _mapper.Map<BrandDto,Brand>(new Brand());
            IList<GetAllProductsQueryResponse> map =_mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map) item.Price -= (item.Price * item.Discount / 100);
                return map;
            
        }
    }
}
