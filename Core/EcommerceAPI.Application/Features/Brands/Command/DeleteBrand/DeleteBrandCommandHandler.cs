using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Brands.Command.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand brand = await _unitOfWork.GetReadRepository<Brand>().GetAsync(b=>b.Id == request.Id && !b.IsDeleted);
            brand.IsDeleted = true;

            await _unitOfWork.GetWriteRepository<Brand>().UpdateAsync(brand);
            await _unitOfWork.SaveAsync();
        }
    }
}
