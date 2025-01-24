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

namespace EcommerceAPI.Application.Features.Details.Queries.GetAllDetails
{
    public class GetAllDetailQueryHandler : IRequestHandler<GetAllDetailQueryRequest, IList<GetAllDetailQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDetailQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllDetailQueryResponse>> Handle(GetAllDetailQueryRequest request, CancellationToken cancellationToken)
        {

            IList<Detail> detail = await _unitOfWork.GetReadRepository<Detail>().GetAllAsync(d=> !d.IsDeleted, include: x => x.Include(c => c.Category));

            CategoryDto category = _mapper.Map<CategoryDto, Category>(new Category());

            IList<GetAllDetailQueryResponse> map = _mapper.Map<GetAllDetailQueryResponse,Detail>(detail);

            return map;
        }
    }
}
