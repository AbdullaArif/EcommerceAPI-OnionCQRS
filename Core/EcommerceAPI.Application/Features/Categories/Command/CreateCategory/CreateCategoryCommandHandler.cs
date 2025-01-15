using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entites;
using EcommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = new(request.Priorty, request.Name, request.ParentId);
             await _unitOfWork.GetWriteRepository<Category>().AddAsync(category);

            if(await _unitOfWork.SaveAsync() > 0)
            {
                foreach (var detailId in request.DetailIds)
                {
                    
                    var detail = await _unitOfWork.GetReadRepository<Detail>()
                        .GetAsync(x => x.Id == detailId);

                    if (detail != null)
                    {
                        
                        detail.CategoryId = category.Id; 
                        await _unitOfWork.GetWriteRepository<Detail>().UpdateAsync(detail);
                    }
                }
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
