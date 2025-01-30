using EcommerceAPI.Application.Features.Categories.Rules;
using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryRules _categoryRules;
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, CategoryRules categoryRules)
        {
            _unitOfWork = unitOfWork;
            _categoryRules = categoryRules;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.GetReadRepository<Category>().GetAllAsync() ;
            await _categoryRules.CategoryMustBeUnique(request.Name, categories) ; 


            Category category = new(request.Priorty, request.Name, request.ParentId);
             await _unitOfWork.GetWriteRepository<Category>().AddAsync(category);

            if(await _unitOfWork.SaveAsync() > 0)
            {
                foreach (var detailId in request.DetailIds)
                {

                    Detail detail = await _unitOfWork.GetReadRepository<Detail>()
                        .GetAsync(x => x.Id == detailId);

                    if (detail != null)
                    {
                        
                        detail.CategoryId = category.Id; 
                        await _unitOfWork.GetWriteRepository<Detail>().UpdateAsync(detail);
                    }
                }
                await _unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
