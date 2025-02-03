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

namespace EcommerceAPI.Application.Features.Products.Queries.SearchProducts
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQueryRequest, IList<SearchProductsQueryResponse>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SearchProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<SearchProductsQueryResponse>> Handle(SearchProductsQueryRequest request, CancellationToken cancellationToken)
        {
           
            Expression<Func<Product, bool>> predicate = p =>
                (string.IsNullOrEmpty(request.Tittle) || p.Tittle.Contains(request.Tittle)) &&
                (string.IsNullOrEmpty(request.Description) || p.Description.Contains(request.Description)) &&
                (request.Brand == null || p.Brand.Name == request.Brand.Name) &&
                (!request.MinPrice.HasValue || p.Price >= request.MinPrice.Value) &&
                (!request.MaxPrice.HasValue || p.Price <= request.MaxPrice.Value);
            
            // praductu getirib, relational tablelari daxil etmek
            var products = await _unitOfWork.GetReadRepository<Product>().GetAllByPagingAsync(
                predicate: predicate,
                include: q => q.Include(p => p.Brand),
                orderBy: q => q.OrderBy(p => p.Tittle),
                enableTracking: false,
                currentPage: request.Page,
                pageSize: request.PageSize
            );

            var map = _mapper.Map<SearchProductsQueryResponse, Product>(products);
            return map;

            //return products.Select(p => new SearchProductsQueryResponse
            //{
            //    Id = p.Id,
            //    Tittle = p.Tittle,
            //    Description = p.Description,
            //    Price = p.Price,
            //    Discount = p.Discount,
            //    BrandName = p.Brand.Name
            //}).ToList();

        }
    
    }
}
