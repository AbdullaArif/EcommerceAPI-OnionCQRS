using EcommerceAPI.Application.Interfaces.AutoMapper;
using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Queries.SearchDetails
{
    public class SearchDetailsQueryHandler : IRequestHandler<SearchDetailsQueryRequest, IList<SearchDetailsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<SearchDetailsQueryResponse>> Handle(SearchDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Detail, bool>> predicate = d =>
               (string.IsNullOrEmpty(request.Tittle) || d.Tittle.Contains(request.Tittle)) &&
               (string.IsNullOrEmpty(request.Description) || d.Description.Contains(request.Description)) &&
               (request.CategoryDto == null || d.Category.Name == request.CategoryDto.Name);

            var details = await _unitOfWork.GetReadRepository<Detail>().GetAllByPagingAsync(
                predicate : predicate,
                include :   q=>q.Include(d=>d.Category),
                orderBy :   q=>q.OrderBy(d=>d.Tittle),
                 currentPage: request.Page,
                pageSize: request.PageSize
            );

            var mappedDetail = _mapper.Map<SearchDetailsQueryResponse,Detail>(details);
            return mappedDetail;

        }
    }
}
