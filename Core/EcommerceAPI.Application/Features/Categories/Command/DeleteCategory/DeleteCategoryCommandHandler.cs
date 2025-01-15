using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _unitOfWork.GetReadRepository<Category>().GetAsync(c=>c.Id == request.Id && !c.IsDeleted);

            category.IsDeleted = true;

            await _unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
