using EcommerceAPI.Application.DTOs;
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

namespace EcommerceAPI.Application.Features.Details.Queries.GetByIdDetail
{
    public class GetByIdDetailQueryHandler: IRequestHandler<GetByIdDetailQueryRequest,GetByIdDetailQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetByIdDetailQueryResponse> Handle(GetByIdDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var detail = await _unitOfWork.GetReadRepository<Detail>().GetAsync(d=>d.Id == request.Id && !d.IsDeleted,
            include: x=>x.Include(c=>c.Category));

            CategoryDto category = _mapper.Map<CategoryDto, Category>(new Category());

            var map = _mapper.Map<GetByIdDetailQueryResponse, Detail>(detail);

            return map;

        }
    }
}
