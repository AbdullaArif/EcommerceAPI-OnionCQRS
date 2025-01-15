using EcommerceAPI.Application.Interfaces.AutoMapper;
using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entites;
using EcommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _unitOfWork.GetReadRepository<Category>()
                .GetAsync(c => c.Id == request.Id && !c.IsDeleted, include: x => x.Include(d => d.Details));

            var map = _mapper.Map<Category, UpdateCategoryCommandRequest>(request);
            foreach (var detailId in request.DetailIds)
            {

                var detail = await _unitOfWork.GetReadRepository<Detail>()
                    .GetAsync(x => x.Id == detailId && !x.IsDeleted);

                if (detail != null)
                {

                    detail.CategoryId = category.Id;
                    await _unitOfWork.GetWriteRepository<Detail>().UpdateAsync(detail);
                }
            }

            await _unitOfWork.GetWriteRepository<Category>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
        }
    }
}
